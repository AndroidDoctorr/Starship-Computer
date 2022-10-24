using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaStream : KineticProcess
{
    public AntimatterReaction AntimatterReaction;

    public override double Temperature { get { return AntimatterReaction.Temperature; } }
    public event TemperatureChangeDelegate OnTemperatureChange;
    public override double Mdot { get { return AntimatterReaction.PlasmaRatePerEngine; } }
    public event MdotChangeDelegate OnMdotChange;
    public override double V { get { return AntimatterReaction.PlasmaV; } }
    public event VChangeDelegate OnVChange;
    public override double SigmaRadius { get; } = 0.1;
    public event SigmaChangeDelegate OnSigmaChange;
    void Start()
    {
        
    }
    void Update()
    {
        OnTemperatureChange(Temperature);
        OnMdotChange(Mdot);
        OnVChange(V);
        OnSigmaChange(SigmaRadius);
    }
}
