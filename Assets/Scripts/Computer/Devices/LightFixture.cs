using Assets.Scripts.Computer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFixture : Device
{
    private bool _isOn = false;
    private float _intensity;

    public Light Light;
    public GameObject Bulb;
    // Maximum value of 8
    public float MaxIntensity = 1;

    private void OnEnable()
    {
        _intensity = Light.intensity;
        _isOn = Light.intensity != 0;
    }
    private void Start()
    {
        if (MaxIntensity > 8)
            MaxIntensity = 8;
    }
    public void TurnOn()
    {
        _isOn = true;
        Light.intensity = _intensity;
    }
    public void TurnOff()
    {
        _isOn = false;
        Light.intensity = 0;
    }
    public void SetColor(float hue, float value)
    {
        Color color = Color.HSVToRGB(hue, 1, value);
        Light.color = color;

        Material material = Bulb.GetComponentInChildren<Renderer>().material;
        material.color = color;
    }
    public void SetBrightness(float brightness)
    {
        Light.intensity = brightness * MaxIntensity;
        _intensity = brightness;
    }
}
