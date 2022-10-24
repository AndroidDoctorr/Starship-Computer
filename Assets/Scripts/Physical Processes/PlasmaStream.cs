using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaStream : MonoBehaviour, IKineticProcess, IThermalProcess
{
    public AntimatterReaction AntimatterReaction;

    public double Temperature { get { return AntimatterReaction.Temperature; } }
    public event IThermalProcess.TemperatureChangeDelegate OnTemperatureChange;
    public double Mdot { get { return AntimatterReaction.PlasmaRatePerEngine; } }
    public event IKineticProcess.MdotChangeDelegate OnMdotChange;
    public double V { get { return AntimatterReaction.PlasmaV; } }
    public event IKineticProcess.VChangeDelegate OnVChange;
    public double SigmaRadius { get; } = 0.1;
    public event IKineticProcess.SigmaChangeDelegate OnSigmaChange;
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
