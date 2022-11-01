using System;
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
        // Physical Constants
        // TODO: Get this from confinement coils eventually
        private double _confinementBase = 5;
        private double _confinementMax = 100;
        // TODO: Get this from the Injector eventually (property of the hardware used)
        private double _baseRadius = 0.1; // in femtometers?
        // TODO: Get this from the Phase Coil subsystem eventually
        private double _confinementSetting = 0.1;
        // TODO: Get this from the Phase Coil subsystem eventually
        private double _confinementFrequency = 0.3;

        public Injector Injector;
        public ConstrictionCoils Coils;
        public Transform StreamStart;
        public Transform StreamEnd;



        public override double Temperature => 2000;
        public override event TemperatureChangeDelegate OnTemperatureChange;
        public override double V => vFinal;
        public override event VChangeDelegate OnVChange;
        public override double Mdot => FlowRate;
        public override event MdotChangeDelegate OnMdotChange;

        private ParticleSystem _ps;
        private void Start()
        {
            _ps = GetComponentInChildren<ParticleSystem>();
            if (_ps == null) Debug.LogError("Matter stream cannot find particle system!!");
        }
        // Mass flow rate (~1 g/s is typical?)
        public double FlowRate
        {
            get
            {
                return Injector.ActualFlowRate;
            }
        }
        // Velocity at the injector
        public double vInitial { get; }
        // Velocity at the reactor
        public double vFinal { get; }
        // Confinement properties
        public double Confinement => _confinementBase + (_confinementMax - _confinementBase) * _confinementSetting;
        public double Amplitude => (_baseRadius / Math.Pow(Confinement, 2));
        public override double SigmaRadius => Amplitude;
        public override event SigmaChangeDelegate OnSigmaChange;
        // public double GetSigmaRadiusAt(Transform location)
        // {
        // double phi = 0.5; // Ratio of phase frequency
        // double theta =  
        // return Amplitude * Math.Sin();
        // }
        // Density of the stream at the reactor
        public double Density
        {
            get
            {
                double area = Mathf.PI * Math.Pow(SigmaRadius, 2);
                return FlowRate / vFinal / area;
            }
        }
    }
}
