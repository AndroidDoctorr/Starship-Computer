using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IThermalProcess
{
    public double Temperature { get; }
    public delegate void TemperatureChangeDelegate(double newTemp);
    public event TemperatureChangeDelegate OnTemperatureChange;
}
