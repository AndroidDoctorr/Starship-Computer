using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Atmosphere;

public class HumiditySensor : MonoBehaviour
{
    public Atmosphere Atmosphere;
    public delegate void HumidityChangeDelegate(double newHumidity);
    public event HumidityChangeDelegate OnHumidityChange;
    void OnEnable()
    {
        Atmosphere.OnHumidityChange += UpdateHumidity;
    }
    private void OnDestroy()
    {
        Atmosphere.OnHumidityChange -= UpdateHumidity;
    }
    private void UpdateHumidity(double newHumidity)
    {
        OnHumidityChange(newHumidity);
    }
    public double GetHumidity()
    {
        return Atmosphere.Humidity;
    }
}
