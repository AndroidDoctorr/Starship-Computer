using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermalProcess : MonoBehaviour
{
    public virtual double Mass { get; protected set; } // Kg
    public double HeatCapacity { get; protected set; } // J / Kg / K
    public virtual double Temperature { get; protected set; } // K
    public double InitialTemperature; // K
    public delegate void TemperatureChangeDelegate(double newTemp);
    public virtual event TemperatureChangeDelegate OnTemperatureChange;
    public ThermalProcess()
    {
        Temperature = InitialTemperature;
    }

    public void AddHeat(double q) // in J
    {
        Temperature += q / Mass / HeatCapacity;
        OnTemperatureChange(Temperature);
    }
    public double GetHeatDifference(double temp) // in K
    {
        // This calculates the energy in J needed to raise/lower temp to T
        return HeatCapacity * Mass * (temp - Temperature);
    }
}
