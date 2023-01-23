using Assets.Scripts.Computer.Core.CoreModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Computer.Devices.CoreDevices
{
    public class SN32LearningModule : MonoBehaviour, ILearningModule
    {
        public Guid Id => new Guid();

        public LearningSocketType Type => LearningSocketType.N1;

        public decimal DataCapacity => 4096;

        public decimal IOCapacity => 32;

        public decimal[] ThermalCoefficients => throw new NotImplementedException();
    }
}
