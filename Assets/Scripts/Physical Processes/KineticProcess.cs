using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKineticProcess
{
    public double Mdot { get; }
    public delegate void MdotChangeDelegate(double newMdot);
    public event MdotChangeDelegate OnMdotChange;
    public double V { get; }
    public delegate void VChangeDelegate(double newV);
    public event VChangeDelegate OnVChange;
    public double SigmaRadius { get; }
    public delegate void SigmaChangeDelegate(double newSigma);
    public event SigmaChangeDelegate OnSigmaChange;
}
