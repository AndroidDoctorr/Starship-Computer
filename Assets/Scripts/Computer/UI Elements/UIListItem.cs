using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIListItem : UIElement
{
    public float Height = 0.625f;
    public delegate void SelectDelegate();
    public event SelectDelegate OnSelect;

    private void OnTriggerEnter(Collider other)
    {
        if (OnSelect != null) OnSelect();
    }

    public virtual void Populate(ListItemData data)
    {

    }
    public override void SetColor(Color color)
    {
        base.SetColor(color);
    }
}

[Serializable]
public class ListItemData
{
    
}
