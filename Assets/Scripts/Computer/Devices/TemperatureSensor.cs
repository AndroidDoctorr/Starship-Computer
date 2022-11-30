using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureSensor : MonoBehaviour
{
    public ThermalProcess ThermalProcess;
    public delegate void TemperatureChangeDelegate(double newTemp);
    public event TemperatureChangeDelegate OnTemperatureChange;
    void OnEnable()
    {
        ThermalProcess.OnTemperatureChange += UpdateTemp;
    }
    private void OnDestroy()
    {
        ThermalProcess.OnTemperatureChange -= UpdateTemp;
    }
    private void UpdateTemp(double newTemp)
    {
        OnTemperatureChange(newTemp);
    }
    public double GetTemperature()
    {
        return ThermalProcess.Temperature;
    }
}
