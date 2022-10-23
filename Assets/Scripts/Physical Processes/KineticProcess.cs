using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKineticProcess
{
    public double Mdot { get; }
    public double V { get; }
    public double SigmaRadius { get; }
}
