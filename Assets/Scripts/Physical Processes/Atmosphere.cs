using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atmosphere : ThermalProcess
{
    public ACUnit ACUnit;
    public override double Temperature => ACUnit.Temperature;
}
