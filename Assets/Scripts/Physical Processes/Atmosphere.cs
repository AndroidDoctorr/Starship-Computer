using Newtonsoft.Json.Bson;
using System;
using UnityEngine;

public class Atmosphere : ThermalProcess
{
    public ACUnit[] ACUnits;
    public double Volume = 1000;
    public double Humidity { get; protected set; } = 0.1;
    public delegate void HumidityChangeDelegate(double newHumid);
    public virtual event HumidityChangeDelegate OnHumidityChange;
    private void Start()
    {
        HeatCapacity = 700;
        Temperature = 295;
        // TODO: Set temp and humidity to AC Unit settings
    }
    public void AddHumidity(double mass)
    {
        // 3rd degree polynomial approximation of Nitrogen/Oxygen mix
        double capacity = -6613
            + 74.3 * Temperature
            + -0.279 * Math.Pow(Temperature, 2)
            + .00035 * Math.Pow(Temperature, 3);
        // grams per cubic meter
        double totalMoisture = capacity * Volume;
    }
}
