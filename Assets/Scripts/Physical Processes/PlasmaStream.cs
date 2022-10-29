using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaStream : KineticProcess
{
    public AntimatterReaction AntimatterReaction;

    public override double Temperature { get { return AntimatterReaction.PlasmaTemperature; } }
    public override event TemperatureChangeDelegate OnTemperatureChange;
    public override double Mdot { get { return AntimatterReaction.PlasmaRatePerEngine; } }
    public override event MdotChangeDelegate OnMdotChange;
    public override double V { get { return AntimatterReaction.PlasmaV; } }
    public override event VChangeDelegate OnVChange;
    public override double SigmaRadius { get; } = 0.1;
    public override event SigmaChangeDelegate OnSigmaChange;
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
