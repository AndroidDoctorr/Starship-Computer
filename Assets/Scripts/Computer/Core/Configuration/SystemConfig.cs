﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Core.Configuration
{
    public class SystemConfig
    {
        public string Name;
        public int Priority;
        IEnumerable<KeyValuePair<string, SubsystemConfig>> Subsystems;
    }
}
