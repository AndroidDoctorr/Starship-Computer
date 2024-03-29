﻿using Assets.Scripts.Computer.Core.CoreModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Computer.Devices.CoreDevices
{
    public class SN32LearningModule : LearningModule
    {
        public SN32LearningModule()
        {
            Id = new Guid();
            SocketType = DataSocketType.N1;
            DataCapacity = 4096;
            CacheSize = 64;
            PowerCap = 108;
            BusSpeed = 32;
            ThermalCoefficients = new decimal[] { };
        }
    }
}
