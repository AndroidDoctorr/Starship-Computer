using Assets.Scripts.Computer.Systems.Warp_Core;
using System;

public class AntimatterReaction : ThermalProcess
{
    // Physical constants
    public static double C = 299792458;
    // Variance constants
    public static double Vcap = 0.01;
    public static double Vdil = 0.01;
    public static double Vrad = 0.01;
    public static double Vvel = 0.01;
    public static double Vmas = 0.0001;
    public static double Vint = 0.01;
    // Efficiency constants
    public static double 

    public MatterStream MatterStream;
    public MatterStream AntimatterStream;
    public DilithiumMatrix DilithiumMatrix;
    public PlasmaStream PortPlasmaStream;
    public PlasmaStream StarboardPlasmaStream;

    public double IntermixRatio => MatterStream.FlowRate / AntimatterStream.FlowRate;
    public double PlasmaRateTotal => MatterStream.FlowRate - AntimatterStream.FlowRate;
    public double PlasmaRatePerEngine => PlasmaRateTotal / 2;
    public double TotalPower => 2 * AntimatterStream.FlowRate * Math.Pow(C, 2);
    public double LossQ => TotalPower * (1 - Efficiency);
    // TODO: Come up with a better way to estimate temp
    public override double Temperature => LossQ / 1000 * Randomness;
    public override event TemperatureChangeDelegate OnTemperatureChange;
    public double PlasmaQ => TotalPower * Efficiency;
    public double PlasmaV => Math.Sqrt(2 * PlasmaQ / PlasmaRateTotal);

    // Efficiency calculations
    public double Efficiency => 0.4;


    // Variance calculations
    public double Randomness => 1 + UnityEngine.Random.Range((float) -Variance, (float) Variance);
    public double Variance =>
        DilithiumCapacityVariance +
        DilithiumUsageVariance +
        SigmaRadiusVariance +
        VelocityVariance +
        MassVariance +
        IntermixVariance;
    // Variance Contributions
    public double DilithiumCapacityVariance => Vcap / (DilithiumMatrix.Capacity);
    public double DilithiumUsageVariance => Vdil * Math.Pow(DilithiumMatrix.Usage, 4);
    public double SigmaRadiusVariance => Vrad / (MatterStream.SigmaRadius * AntimatterStream.SigmaRadius);
    public double VelocityVariance => Vvel / (Math.Sqrt(MatterStream.V) * Math.Sqrt(AntimatterStream.V));
    public double MassVariance => Vmas * Math.Sqrt(AntimatterStream.Mdot);
    public double IntermixVariance => Vint / Math.Pow(IntermixRatio, 2);


    void Update()
    {
        OnTemperatureChange(Temperature);
    }
}
