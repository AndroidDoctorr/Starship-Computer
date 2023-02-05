using Assets.Scripts.Computer.Core.CoreModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Computer.Devices.CoreDevices
{
    public class SD64ProcessingModule : LogicModule
    {
        public SD64ProcessingModule()
        {
            Id = new Guid();
            SocketType = ProcessingSocketType.D1;
            Threads = 4096;
            ClockSpeed = 16;
            BusSpeed = 8;
            CacheSize = 64;
            PowerCap = 108;
            ThermalCoefficients = new decimal[] { 1 };
        }
    }
}
