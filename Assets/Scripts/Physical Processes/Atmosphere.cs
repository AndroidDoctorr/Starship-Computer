using Newtonsoft.Json.Bson;
using System;
using UnityEngine;

public class Atmosphere : ThermalProcess
{
    public ACUnit[] ACUnits;
    public double StartTemp = 295; // Room temperature
    public double StartHumidity = 0.1;
    public double Volume = 1000; // m3
    public double Density { get => 2.42 - 0.00413 * Temperature; } // kg / m3
    public override double Mass { get => Volume * Density; }
    public double Humidity { get; protected set; } // % maximum humidity
    public delegate void HumidityChangeDelegate(double newHumid);
    public virtual event HumidityChangeDelegate OnHumidityChange;
    private void Start()
    {
        HeatCapacity = 700; // Air at STP
        Temperature = StartTemp;
        Humidity = StartHumidity; // Room temperature
    }
    public void AddHumidity(double mass) // g
    {
        // 3rd degree polynomial approximation of maximum water capacity of
        //   Nitrogen/Oxygen mix in g / m3
        double capacity = -6613
            + 74.3 * Temperature
            + -0.279 * Math.Pow(Temperature, 2)
            + .00035 * Math.Pow(Temperature, 3);
        double totalMoisture = capacity * Volume; // g
        double currentMoisture = totalMoisture * Humidity;
        // Add moisture to total humidity
        currentMoisture += mass;
        if (currentMoisture > totalMoisture)
        {
            // TODO: Simulate condensation???
            Humidity = 1;
        }
        else if (currentMoisture < 0)
            Humidity = 0;
        else
            Humidity = currentMoisture / totalMoisture;
    }
}
