using Assets.Scripts;
using Assets.Scripts.Computer.Systems.Environment.SubSystems;
using Assets.Scripts.Computer.UIs.BaseUIs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtmosphereUI : PadUI
{
    public UIPopupMenu Menu;
    
    private void OnEnable()
    {
        Menu.OnToggle += MenuToggle;
    }
    private void OnDestroy()
    {
        Menu.OnToggle -= MenuToggle;
    }

    private void MenuToggle(bool isOpen)
    {

    }
}
