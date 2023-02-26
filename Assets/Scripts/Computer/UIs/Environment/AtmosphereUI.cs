using Assets.Scripts;
using Assets.Scripts.Computer.Core;
using Assets.Scripts.Computer.Systems.Environment.SubSystems;
using Assets.Scripts.Computer.UIs.BaseUIs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtmosphereUI : PadUI
{
    public AtmosphereGroup AtmosphereGroup;

    public UIPopupMenu Menu;
    public UISlider TempSlider;
    public UISlider HumidSlider;
    public UIProperty TempProp;
    public UIProperty HumidProp;
    public override SystemBase System { get { return AtmosphereGroup; } }

    protected override void OnEnable()
    {
        Menu.OnToggle += MenuToggle;

        TempSlider.OnLevelSet += SetTemp;
        HumidSlider.OnLevelSet += SetHumidity;

        TempProp.SetSystem(AtmosphereGroup);
        HumidProp.SetSystem(AtmosphereGroup);

        base.OnEnable();
    }
    protected override void OnDestroy()
    {
        Menu.OnToggle -= MenuToggle;

        TempSlider.OnLevelSet -= SetTemp;
        HumidSlider.OnLevelSet -= SetHumidity;

        base.OnDestroy();
    }
    private void SetTemp(float temp)
    {
        AtmosphereGroup.SetTemperature(temp);
    }
    private void SetHumidity(float humid)
    {
        AtmosphereGroup.SetHumidity(humid);
    }
    private void MenuToggle(bool isOpen)
    {

    }
}
