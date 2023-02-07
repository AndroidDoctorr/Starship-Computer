using Newtonsoft.Json.Bson;
using System;
using UnityEngine;

public class Atmosphere : ThermalProcess
{
    public ACUnit[] ACUnits;
    public double InitialHumidity = 0.1;
    public double Volume = 1000; // m3
    // Linear approximation of density as function of temp
    public double Density { get => 2.42 - 0.00413 * Temperature; } // kg / m3
    public override double Mass { get => Volume * Density; }
    public double Humidity { get; protected set; } // % maximum humidity
    public delegate void HumidityChangeDelegate(double newHumid);
    public virtual event HumidityChangeDelegate OnHumidityChange;

    public Atmosphere()
    {
        InitialTemperature = 295;
        HeatCapacity = 700; // Air at STP
        Humidity = InitialHumidity;
        Temperature = InitialTemperature;
    }

    public void AddHumidity(double mass) // g
    {
        // 3rd poly approximation of maximum water capacity of
        //   N2/O2 mix in g / m3
        double totalMoisture = GetTotalMoisture();
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

        OnHumidityChange(Humidity);
    }
    public double GetTotalMoisture()
    {
        double capacity = -6613
            + 74.3 * Temperature
            + -0.279 * Math.Pow(Temperature, 2)
            + .00035 * Math.Pow(Temperature, 3);
        return capacity * Volume; // g
    }
    public double GetMoistureDifference(double targetHumidity)
    {
        return (targetHumidity - Humidity) * GetTotalMoisture(); // g
    }
}
