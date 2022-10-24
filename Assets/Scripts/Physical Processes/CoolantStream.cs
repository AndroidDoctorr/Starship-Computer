using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolantStream : KineticProcess
{
    public AntimatterReaction AntimatterReaction;

    public override double Temperature { get { return AntimatterReaction.Temperature; } }
    public override event TemperatureChangeDelegate OnTemperatureChange;
    public override double Mdot { get { return AntimatterReaction.PlasmaRatePerEngine; } }
    public override event MdotChangeDelegate OnMdotChange;
    public override double V { get { return AntimatterReaction.PlasmaV; } }
    public override event VChangeDelegate OnVChange;
    void Update()
    {
        OnTemperatureChange(Temperature);
        OnMdotChange(Mdot);
        OnVChange(V);
    }
}
