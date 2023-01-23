using Assets.Scripts.Computer.Core.CoreModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Computer.Devices.CoreDevices
{
    public class SD64ProcessingModule : MonoBehaviour, IProcessingModule
    {
        public ProcessingSocketType SocketType => ProcessingSocketType.D1;

        public int Threads => 4096;

        public decimal ClockSpeed => 16;

        public decimal BusSpeed => 8;

        public decimal CacheSize => 64;

        public decimal[] ThermalCoefficients => new decimal[] { 1 };
    }
}
