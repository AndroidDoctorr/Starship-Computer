using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaStream : MonoBehaviour, IKineticProcess, IThermalProcess
{
    public AntimatterReaction AntimatterReaction;

    public double Temperature { get { return AntimatterReaction.Temperature; } }
    public double Mdot { get { return AntimatterReaction.PlasmaRatePerEngine; } }
    public double V { get { return AntimatterReaction.PlasmaV; } }
    public double SigmaRadius { get; } = 0.1;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
