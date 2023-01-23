using Assets.Scripts.Computer.Core.CoreModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Computer.Devices.CoreDevices
{
    public class SN86MemoryModule : MonoBehaviour, IMemoryModule
    {
        public MemorySocketType Type => MemorySocketType.N1;

        public decimal DataCapacity => 1024;

        public decimal IOCapacity => 86;

        public decimal[] ThermalCoefficients => new decimal[] { 1 };
    }
}
