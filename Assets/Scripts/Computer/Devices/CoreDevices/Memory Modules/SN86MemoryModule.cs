using Assets.Scripts.Computer.Core.CoreModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Computer.Devices.CoreDevices
{
    public class SN86MemoryModule : MemoryModule
    {
        public SN86MemoryModule()
        {
            Id = new Guid();
            SocketType = MemorySocketType.N1;
            DataCapacity = 1024;
            CacheSize = 64;
            PowerCap = 108;
            BusSpeed = 32;
            ThermalCoefficients = new decimal[] { 1 };
        }
    }
}
