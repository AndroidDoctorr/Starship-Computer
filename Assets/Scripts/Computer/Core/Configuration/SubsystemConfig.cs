﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Core.Configuration
{
    [Serializable]
    public class SubsystemConfig
    {
        public string Name;
        public int Priority;
        public int Address;
        IEnumerable<DeviceConfig> Devices;
    }
}
