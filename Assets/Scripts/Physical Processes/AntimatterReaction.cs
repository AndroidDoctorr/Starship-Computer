using Assets.Scripts.Computer.Systems.Warp_Core;
using System;

public class AntimatterReaction : ThermalProcess
{
    // Physical constants
    public static double C = 299792458;
    public static double Cplasma = 143044; // Heat capacity of 
    // Variance constants
    public static double Vcap = 0.01;
    public static double Vdil = 0.01;
    public static double Vrad = 0.01;
    public static double Vvel = 0.01;
    public static double Vmas = 0.0001;
    public static double Vint = 0.01;
    // Efficiency constants
    public static double Erad = 0.1;
    public static double Econ = 0.1;
    public static double Emas = 0.1;
    public static double Eint = 0.1;
    // Physical interactions
    public MatterStream MatterStream;
    public MatterStream AntimatterStream;
    public DilithiumMatrix DilithiumMatrix;
    public PlasmaStream PortPlasmaStream;
    public PlasmaStream StarboardPlasmaStream;

    // Reaction properties
    public double IntermixRatio => MatterStream.FlowRate / AntimatterStream.FlowRate;
    public double TotalPower => 2 * AntimatterStream.FlowRate * Math.Pow(C, 2) * Randomness;
    public double PlasmaEnergy => TotalPower * Efficiency;
    public double LossQ => TotalPower * (1 - Efficiency);
    // TODO: Come up with a better way to estimate temp
    public override double Temperature => (LossQ / 1000);
    public override event TemperatureChangeDelegate OnTemperatureChange;
    // Output properties
    public double Output => PlasmaRateTotal * PlasmaV;
    public double PlasmaRateTotal => MatterStream.FlowRate - AntimatterStream.FlowRate;
    public double PlasmaRatePerEngine => PlasmaRateTotal / 2;
    public double PlasmaQ => PlasmaEnergy * (1 - Efficiency);
    public double PlasmaK => PlasmaEnergy * Efficiency;
    public double PlasmaV => Math.Sqrt(2 * PlasmaK / PlasmaRateTotal);
    public double PlasmaTemperature => PlasmaQ / (PlasmaRateTotal * Cplasma);


    // Efficiency Calculations
    public double Efficiency => 
        SigmaRadiusEffect * 
        ConfinementEffect *
        MassEffect *
        IntermixEffect;
    // Efficiency Contributions
    public double SigmaRadiusEffect => 1 - Erad * MatterStream.SigmaRadius * AntimatterStream.SigmaRadius;
    public double ConfinementEffect => 1 - Econ; // TODO: No confinement field property defined yet
    public double MassEffect => 1 - Emas / (Math.Sqrt(AntimatterStream.Mdot) * Math.Sqrt(MatterStream.Mdot));
    public double IntermixEffect => 1 - Erad / IntermixRatio;


    // Variance Calculations
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
