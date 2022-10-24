using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermalProcess : MonoBehaviour
{
    public virtual double Temperature { get; }
    public delegate void TemperatureChangeDelegate(double newTemp);
    public event TemperatureChangeDelegate OnTemperatureChange;
}
