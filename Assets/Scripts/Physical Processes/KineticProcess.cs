using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticProcess : ThermalProcess
{
    public virtual double Mdot { get; }
    public delegate void MdotChangeDelegate(double newMdot);
    public virtual event MdotChangeDelegate OnMdotChange;
    public virtual double V { get; }
    public delegate void VChangeDelegate(double newV);
    public virtual event VChangeDelegate OnVChange;
    public virtual double SigmaRadius { get; }
    public delegate void SigmaChangeDelegate(double newSigma);
    public virtual event SigmaChangeDelegate OnSigmaChange;
}
