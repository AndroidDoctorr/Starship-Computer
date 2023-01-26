using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIListItem : UIElement
{
    public float Height = 0.625f;
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
    public string[] Strings;
    public string[] Labels;
    public float[] Numbers;
    public GameObject[] GameObjects;
}
