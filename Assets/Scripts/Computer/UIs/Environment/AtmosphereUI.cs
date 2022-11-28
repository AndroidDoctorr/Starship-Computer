using Assets.Scripts;
using Assets.Scripts.Computer.Systems.Environment.SubSystems;
using Assets.Scripts.Computer.UIs.BaseUIs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtmosphereUI : PadUI
{
    public UIPopupMenu Menu;
    public UISlider TempSlider;
    public UISlider HumidSlider;
    public UIProperty TempProp;
    public UIProperty HumidProp;
    
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
