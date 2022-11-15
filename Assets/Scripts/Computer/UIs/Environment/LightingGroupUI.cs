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
    public UIButton Multiple;
    private void Start()
    {
        if (LightingGroup.BeginOn)
        {
            Toggle.SetToOn(true);
            ColorInput.SetKnobColor(LightingGroup.DefaultColor);
            BrightnessSlider.SlideTo(LightingGroup.DefaultBrightness);
        }
    }

    private void OnEnable()
    {
        ColorInput.OnLevelSet += SetColor;
        BrightnessSlider.OnLevelSet += SetBrightness;
        Toggle.onToggle += ToggleGroup;
        CandleMode.onButtonPress += SetCandleMode;
        Random.onButtonPress += SetRandomMode;
        Multiple.onButtonPress += SetMultipleMode;
    }
    private void OnDestroy()
    {
        ColorInput.OnLevelSet -= SetColor;
        BrightnessSlider.OnLevelSet -= SetBrightness;
        Toggle.onToggle -= ToggleGroup;
        CandleMode.onButtonPress -= SetCandleMode;
        Random.onButtonPress -= SetRandomMode;
        Multiple.onButtonPress -= SetMultipleMode;
    }
    private void SetColor(string action, GameObject interactor, float unSaturation, float hue)
    {
        float saturation = 1 - unSaturation;
        LightingGroup.SetGroupColor(hue, saturation);
        ColorInput.SetKnobColor(Color.HSVToRGB(hue, saturation, 1));
    }
    private void SetBrightness(float brightness)
    {
        LightingGroup.SetGroupBrightness(brightness);
    }
    private void ToggleGroup(string actionName, GameObject hand)
    {
        if (LightingGroup.IsOn) LightingGroup.TurnOffAllLights();
        else LightingGroup.TurnOnAllLights(false);
    }
    private void SetCandleMode(string actionName, GameObject hand)
    {
        LightingGroup.SetCandleMode();
    }
    private void SetRandomMode(string actionName, GameObject hand)
    {
        LightingGroup.SetRandomColor();
    }
    private void SetMultipleMode(string actionName, GameObject hand)
    {
        LightingGroup.SetMultipleColors();
    }
}
