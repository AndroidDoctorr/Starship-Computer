using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atmosphere : ThermalProcess
{
    public ACUnit ACUnit;
    public override double Temperature => ACUnit.Temperature;
    public double Humidity { get; protected set; }
    public delegate void HumidityChangeDelegate(double newHumid);
    public virtual event HumidityChangeDelegate OnHumidityChange;

    public Atmosphere()
    {
        HeatCapacity = 700;
    }
    public void AddHumidity(double mass)
    {
        double capacity = -6613
            + 74.3 * Temperature
            + -0.279 * Math.Pow(Temperature, 2)
            + .00035 * Math.Pow(Temperature, 3);
        // grams per cubic meter
        double totalMoisture = capacity * GetVolume();
    }
    public double GetVolume()
    {
        return 0;
    }
}
