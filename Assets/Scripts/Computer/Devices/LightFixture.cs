using Assets.Scripts.Computer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFixture : Device
{
    private bool _isOn = false;
    private float _intensity;
    private Color _color;

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
        // Apply settings
        Light.intensity = _intensity;
        Light.color = _color;
        Material material = Bulb.GetComponentInChildren<Renderer>().material;
        material.color = _color;
    }
    public void TurnOff()
    {
        _isOn = false;
        // Reset color/intensity
        Light.intensity = 0;
        Light.color = Color.white;
        Material material = Bulb.GetComponentInChildren<Renderer>().material;
        material.color = Color.white;
    }
    public void SetColor(float hue, float saturation)
    {
        Color color = Color.HSVToRGB(hue, saturation, 1);
        _color = color;

        if (!_isOn) return;

        Light.color = color;

        Material material = Bulb.GetComponentInChildren<Renderer>().material;
        material.color = color;
    }
    public void SetBrightness(float brightness)
    {
        _intensity = brightness;

        if (!_isOn) return;
        
        Light.intensity = brightness * MaxIntensity;
    }
}
