using Assets.Scripts;
using Assets.Scripts.Computer;
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
    }
    void Update()
    {

    }
    private void SetSystem(ISystem system)
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



            if (prop != null)
        {
            string value = prop.GetValue(PropertyName).ToString();
            ValueText.text = value;
        }
    }
    private void UpdateProperty(string newValue)
    {
        ValueText.text = newValue;
    }
    public override void SetColor(Color color)
    {
        Border.color = color;
        ValueText.color = color;
    }
}
