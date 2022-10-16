using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : UIElement
{
    public Image Border;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public override void SetColor(Color color)
    {
        Border.color = color;
    }
}
