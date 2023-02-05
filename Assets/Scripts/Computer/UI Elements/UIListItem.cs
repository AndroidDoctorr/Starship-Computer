using Assets.Scripts;
using Assets.Scripts.Computer.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIListItem : UIElement
{
    public TMP_Text Name;
    public Image Border;
    public float Spacing = 0.125f;

    public delegate void SelectDelegate();
    public event SelectDelegate OnSelect;

    private void OnTriggerEnter(Collider other)
    {
        if (OnSelect != null) OnSelect();
    }

    public virtual void Populate(ListItemData data)
    {

    }
    public virtual void ConnectSystem(SystemBase system)
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
