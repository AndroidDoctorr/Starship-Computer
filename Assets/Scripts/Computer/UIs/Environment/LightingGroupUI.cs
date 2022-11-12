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
        BrightnessSlider.OnLevelSet += SetBrightness;
        Toggle.onToggle += ToggleGroup;
    }
    private void OnDestroy()
    {
        ColorSlider.OnLevelSet -= SetColor;
        BrightnessSlider.OnLevelSet -= SetBrightness;
        Toggle.onToggle -= ToggleGroup;
    }
    private void SetColor(float hue)
    {
        LightingGroup.SetGroupColor(hue);
    }
    private void SetBrightness(float brightness)
    {
        LightingGroup.SetGroupBrightness(brightness);
    }
    private void ToggleGroup(string sourceName, string actionName, GameObject hand)
    {
        if (LightingGroup.IsOn) LightingGroup.TurnOffAllLights();
        else LightingGroup.TurnOnAllLights();
    }
}
