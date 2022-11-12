using Assets.Scripts;
using Assets.Scripts.Computer.Systems.Environment.SubSystems;
using Assets.Scripts.Computer.UIs.BaseUIs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingGroupUI : PadUI
{
    public LightingGroup LightingGroup;

    public UISlider ColorSlider;
    public UISlider BrightnessSlider;
    public UIToggle Toggle;

    private void OnEnable()
    {
        ColorSlider.OnLevelSet += SetColor;
    }
    private void OnDestroy()
    {
        ColorSlider.OnLevelSet -= SetColor;
    }

    private void SetColor(float hue)
    {
        LightingGroup.SetGroupColor(hue);
    }
}
