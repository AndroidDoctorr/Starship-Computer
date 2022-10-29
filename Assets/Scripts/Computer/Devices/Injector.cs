using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Computer.Systems.Warp_Core
{
    public class Injector : Device
    {
        protected double _baseRate = 0.00025;    // Used for determining matter flow rate
        protected double _targetFlowRate = 0;
        protected double acceleration = 0.01f;
        protected bool _accelerating = false;
        public double FlowRate { get; private set; } // g/s
        public double ActualFlowRate
        {
            get
            {
                float variation = 0.01f * Mathf.Pow((float) FlowLevel, 2);
                return FlowRate * Random.Range(1 - variation, 1 + variation);
            }
        }
        public double FlowLevel { get; private set; } // %
        public double InitialVelocity = 10000; // m/s
        protected void SetFlowRate(double flowRate)
        {
            _targetFlowRate = flowRate;
            if (FlowRate != _targetFlowRate)
                _accelerating = true;
        }
        protected void Update()
        {
            if (_accelerating) Accelerate();
        }
        protected void Accelerate()
        {
            double deltaV = _targetFlowRate - FlowRate;
            int direction = Math.Sign(deltaV);
            if (Math.Abs(deltaV) < acceleration * Time.deltaTime)
            {
                FlowRate = _targetFlowRate;
                PowerProfile.SetPowerDraw(0, 100 * FlowRate);
                _accelerating = false;
            }
            else
            {
                // Arbitrary equation do describe power
                bool canSetPower = SetPowerDraw(0, 110 * FlowRate);
                if (canSetPower)
                    FlowRate += acceleration * Time.deltaTime * direction;
                else {
                    Debug.LogError("Unable to comply. Injector power level exceeds power profile maximum draw.");
                    _accelerating = false;
                }
            }
        }
        public void SetFlowLevel(float level, int priority)
        {
            if (level < 0) throw new Exception("Flow level cannot be negative");
            if (level > 1) throw new Exception("Flow level cannot exceed 100%");
            else if (level > 0.9 && priority > 1)
            {
                string errorMessage = "Command authorization required to exceed 90% maximum antimatter flow rate";
                Debug.LogError(errorMessage);
                // throw new Exception(errorMessage);
            }
            else if (level < 0.1 && priority > 1)
            {
                string errorMessage = "Command authorization required to shut down Reactor";
                Debug.LogError(errorMessage);
                // throw new Exception(errorMessage);
            }

            // Mass Flow Rate Equation (Calibrated to increase exponentially from normal output at 5% and max output at 100%)
            double flowRate = _baseRate * Math.Exp(9.105 * level);
            SetFlowRate(flowRate);
            FlowLevel = level;
        }
    }
    public class AntimatterInjector : Injector
    {

    }
    public class MatterInjector : Injector
    {
        public MatterInjector()
        {
            _baseRate = 0.05;
        }
    }
}
