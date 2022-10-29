using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolantStream : KineticProcess
{
    public AntimatterReaction AntimatterReaction;
    private static double _CoolantCapacity = 50;
    private static double _CoolantRate = 20;
    private static double _CoolantDensity = 1;
    private static double _PumpArea = 1;
    private static double _ReactorCapacity = 10;

    public override double Temperature =>
        (AntimatterReaction.Temperature * _ReactorCapacity) / _CoolantCapacity;
    public override event TemperatureChangeDelegate OnTemperatureChange;
    public override double Mdot => Temperature / _CoolantRate;
    public override event MdotChangeDelegate OnMdotChange;
    public override double V => Mdot / _CoolantDensity / _PumpArea;
    public override event VChangeDelegate OnVChange;
    void Update()
    {
        OnTemperatureChange(Temperature);
        OnMdotChange(Mdot);
        OnVChange(V);
    }
}
