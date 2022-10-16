using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScreen : UIElement
{
    public Image Border;
    public TMP_Text Label;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void SetColor(Color color)
    {
        Border.color = color;
        Label.color = color;
    }
}
