using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIProperty : UIElement
{
    public Image Border;
    public TMP_Text LabelText;
    public TMP_Text ValueText;
    public string Label;
    void Start()
    {
        if (!string.IsNullOrWhiteSpace(Label))
            LabelText.text = Label;
    }
    void Update()
    {

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
