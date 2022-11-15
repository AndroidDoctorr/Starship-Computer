using Assets.Scripts;
using Assets.Scripts.Computer.Systems.Environment.SubSystems;
using Assets.Scripts.Computer.UIs.BaseUIs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingGroupUI : PadUI
{
    public LightingGroup LightingGroup;

    public UIXYInput ColorInput;
    public UISlider BrightnessSlider;
    public UIToggle Toggle;
    public UIButton CandleMode;
    public UIButton Random;
    public UIButton MultipleRandom;
    private void Start()
    {
        if (LightingGroup.BeginOn)
        {
            Toggle.SetToOn(true);
            ColorInput.SetKnobColor(LightingGroup.DefaultColor);
            BrightnessSlider.SlideTo(LightingGroup.DefaultIntensity / LightingGroup.MaxIntensity);
        }
    }

    private void OnEnable()
    {
        ColorInput.OnLevelSet += SetColor;
        BrightnessSlider.OnLevelSet += SetBrightness;
        Toggle.onToggle += ToggleGroup;
    }
    private void OnDestroy()
    {
        ColorInput.OnLevelSet -= SetColor;
        BrightnessSlider.OnLevelSet -= SetBrightness;
        Toggle.onToggle -= ToggleGroup;
    }
    private void SetColor(float unSaturation, float hue)
    {
        float saturation = 1 - unSaturation;
        LightingGroup.SetGroupColor(hue, saturation);
        ColorInput.SetKnobColor(Color.HSVToRGB(hue, saturation, 1));
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
