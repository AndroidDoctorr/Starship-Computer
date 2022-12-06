﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Core.Configuration
{
    public class NetworkConfig
    {
        public string Name;
        public int Priority;
        public int Address;
        IEnumerable<KeyValuePair<string, SystemConfig>> Systems;
    }
}
