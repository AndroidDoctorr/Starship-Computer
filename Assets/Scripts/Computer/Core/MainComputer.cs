﻿using Assets.Scripts.Computer.Core;
using Assets.Scripts.Computer.Core.CoreModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer
{
    public class MainComputer
    {
        private PowerAllocator _powerAllocator;
        // Computer Core
        public IComputerCore ComputerCore { get; private set; }
        public ICollection<IThermalModule> ThermalModules { get; private set; }
        public ICollection<IPowerModule> PowerModules { get; private set; }

        // Power Supply
        // IPowerSupply

        // Thermal Management
        // IHeatManagement

        // Systems
        // ICollection<ISystem>

        // Networks
        // ICollection<INetwork>
        public MainComputer()
        {
            var powerProfiles = new Dictionary<string, PowerProfile>();
            _powerAllocator = new PowerAllocator(PowerModules, (ICollection<PowerProfile>) powerProfiles);
        }
    }
}
