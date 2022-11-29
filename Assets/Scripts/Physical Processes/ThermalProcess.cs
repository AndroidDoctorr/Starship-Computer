using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermalProcess : MonoBehaviour
{
    public double Mass { get; protected set; }
    public double HeatCapacity { get; protected set; }
    public virtual double Temperature { get; protected set; }
    public delegate void TemperatureChangeDelegate(double newTemp);
    public virtual event TemperatureChangeDelegate OnTemperatureChange;

    public void AddHeat(double q)
    {
        Temperature += q / Mass / HeatCapacity;
        OnTemperatureChange(Temperature);
    }
}
