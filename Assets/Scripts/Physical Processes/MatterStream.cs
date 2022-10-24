﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using UnityEngine;

namespace Assets.Scripts.Computer.Systems.Warp_Core
{
    public class MatterStream : KineticProcess
    {
        public Injector Injector;
        public ConstrictionCoils Coils;

        public override double Temperature { get; }
        public event TemperatureChangeDelegate OnTemperatureChange;
        public override double V { get { return (vFinal + vInitial) / 2; } }
        public event VChangeDelegate OnVChange;
        public override double Mdot { get { return FlowRate; } }
        public event MdotChangeDelegate OnMdotChange;

        private ParticleSystem _ps;
        private void Start()
        {
            _ps = GetComponentInChildren<ParticleSystem>();
            if (_ps == null) Debug.LogError("Matter stream cannot find particle system!!");
        }
        // Mass flow rate (~1 g/s is typical?)
        public double FlowRate {
            get
            {
                return Injector.ActualFlowRate;
            }
        }
        // Velocity at the injector
        public double vInitial { get; }
        // Velocity at the reactor
        public double vFinal { get; }
        // Confinement - radius that contains 1 sigma of plasma concentration
        public override double SigmaRadius { get; }
        public event SigmaChangeDelegate OnSigmaChange;
        // Density of the stream at the reactor
        public double Density {
            get
            {
                double area = Mathf.PI * Math.Pow(SigmaRadius, 2);
                return FlowRate / vFinal / area;
            }
        }
    }
}
