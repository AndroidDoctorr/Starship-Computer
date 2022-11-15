using Assets.Scripts.Computer;
using Assets.Scripts.Computer.Systems.Environment.SubSystems;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class LightFixture : Device
{
    private bool _isOn = false;
    private bool _isCandleMode = false;
    private float _candleSeed = 0;
    private float _intensity = 0.5f;
    private Color _color = Color.white;

    public Light Light;
    public GameObject Bulb;
    // This can limit a light fixture's intensity below the built-in limit of 8
    public float MaxIntensity = LightingGroup.MaxIntensity;

    private void OnEnable()
    {
        _intensity = Light.intensity;
        _isOn = Light.intensity != 0;
    }
    private void Start()
    {
        // Limit must be equal to or lower than Unity limit
        if (MaxIntensity > LightingGroup.MaxIntensity)
            MaxIntensity = LightingGroup.MaxIntensity;
    }
    private void Update()
    {
        if (_isCandleMode)
        {
            float z = Mathf.PerlinNoise(_candleSeed, Time.time * 5);
            float brightness = (Mathf.Pow(z, 4) / 10f) + 0.25f;
            Light.intensity = brightness * MaxIntensity;
        }
    }
    public void TurnOn()
    {
        _isOn = true;
        // Apply settings
        Light.intensity = _intensity;
        ApplyColor(_color);
    }
    public void TurnOff()
    {
        _isOn = false;
        // Reset color/intensity
        Light.intensity = 0;
        ApplyColor(Color.white);
    }
    public void SetColor(float hue, float saturation)
    {
        if (_isCandleMode) _isCandleMode = false;

        Color color = Color.HSVToRGB(hue, saturation, 1);
        _color = color;

        if (_isOn) ApplyColor(color);
    }
    private void ApplyColor(Color color)
    {
        Light.color = color;

        Material material = Bulb.GetComponent<Renderer>().material;
        material.color = color;
    }
    public void SetBrightness(float brightness)
    {
        if (_isCandleMode) _isCandleMode = false;
        // Brightness is a float between 0 and 1
        // Intensity is a float between 0 and MaxIntensity
        float intensity = brightness * MaxIntensity;
        _intensity = intensity;

        if (!_isOn) return;
        
        Light.intensity = intensity;
    }
    public void SetCandleMode()
    {
        _candleSeed = Random.Range(0, 10f);

        Color flameColor = new Color(1, 0.6f, 0.25f);
        ApplyColor(flameColor);

        _isCandleMode = true;
    }
}
