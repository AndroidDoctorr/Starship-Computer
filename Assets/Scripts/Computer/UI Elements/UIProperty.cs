using Assets.Scripts;
using Assets.Scripts.Computer;
using Assets.Scripts.Computer.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UI;
using static SteamVR_Utils;

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
        SetValue(prop, system);
    }

    private void UpdateProperty(string propertyName, object newValue, params object[] parameters)
    {
        if (propertyName != PropertyName) return;
        SetValueString(newValue);
    }
    private void SetValue(PropertyInfo prop, ISystem system)
    {
        object obj = prop.GetValue(system);
        SetValueString(obj);
    }
    private void SetValueString(object obj)
    {
        string valueString;
        if (obj.GetType() == typeof(double) || obj.GetType() == typeof(float))
            valueString = $"{obj:0.#}";
        else
            valueString = obj.ToString();
        ValueText.text = valueString;
    }
    public override void SetColor(Color color)
    {
        Border.color = color;
        ValueText.color = color;
    }
}
