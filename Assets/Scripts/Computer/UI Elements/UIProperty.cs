using Assets.Scripts;
using Assets.Scripts.Computer;
using Assets.Scripts.Computer.Core;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIProperty : UIElement
{
    public Image Border;
    public TMP_Text LabelText;
    public TMP_Text ValueText;
    public string Label;
    public string PropertyName;
    void Start()
    {
        if (!string.IsNullOrWhiteSpace(Label))
            LabelText.text = Label;
        else if (!string.IsNullOrWhiteSpace(PropertyName))
            LabelText.text = PropertyName;
    }
    void Update()
    {

    }
    public void SetSystem(ISystem system)
    {
        if (system == null)
        {
            Debug.LogError("UI Property - No system provided");
            return;
        }
        System.Type systemType = system.GetType();
        PropertyInfo prop = systemType.GetProperty(PropertyName);
        if (prop == null)
        {
            Debug.LogError("UI Property - Prop does not exist on system");
            return;
        }
        system.OnPropertyChange += UpdateProperty;
    }
    private void UpdateProperty(string propertyName, object newValue)
    {
        if (propertyName != PropertyName) return;
        ValueText.text = newValue.ToString();
    }
    public override void SetColor(Color color)
    {
        Border.color = color;
        ValueText.color = color;
    }
}
