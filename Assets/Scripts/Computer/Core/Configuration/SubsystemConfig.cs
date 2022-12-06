﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Core.Configuration
{
    public class SubsystemConfig
    {
        public string Name;
        IEnumerable<KeyValuePair<string, DeviceConfig>> Devices;
    }
}
