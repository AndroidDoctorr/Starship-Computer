using Assets.Scripts.Computer.Systems.Warp_Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntimatterReaction : MonoBehaviour
{
    public static double C = 299792458;

    public MatterStream MatterStream;
    public MatterStream AntimatterStream;

    public double IntermixRatio => MatterStream.FlowRate / AntimatterStream.FlowRate;
    public double PlasmaRateTotal => MatterStream.FlowRate - AntimatterStream.FlowRate;
    public double PlasmaRatePerEngine => PlasmaRateTotal / 2;
    // TODO: Come up with a way to estimate/change efficiency
    public double Efficiency => 0.4;
    public double TotalPower => 2 * AntimatterStream.FlowRate * Math.Pow(C, 2);
    public double LossQ => TotalPower * (1 - Efficiency);
    // TODO: Come up with a better way to estimate temp
    public double Temp => LossQ / 1000 * Randomness;
    public double PlasmaQ => TotalPower * Efficiency;
    public double PlasmaV => Math.Sqrt(2 * PlasmaQ / PlasmaRateTotal);
    // TODO: What leads to variance???
    // - Reaction naturally has some variance
    // - Increasing output increases variance
    // - Reaction stabilization via dilithium matrix reduces variance
    // - Stream confinement reduces variance (costs energy, maxes out)
    // - Reactor confinement reduces variance (costs energy, maxes out)
    public float Variance = 0.05f;
    // Variance = DilithiumMatrix.Variance * 
    public double Randomness => 1 + UnityEngine.Random.Range(-Variance, Variance);

    void Start()
    {

    }

    void Update()
    {

    }
}
