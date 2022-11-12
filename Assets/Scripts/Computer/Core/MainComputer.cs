using Assets.Scripts.Computer.Core;
using Assets.Scripts.Computer.Core.CoreModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Computer
{
    public class MainComputer : MonoBehaviour
    {
        private PowerAllocator _powerAllocator;
        // Computer Core
        public IComputerCore ComputerCore { get; private set; }
        public ICollection<IThermalModule> ThermalModules { get; private set; } = new List<IThermalModule>();
        public ICollection<IPowerModule> PowerModules { get; private set; } = new List<IPowerModule>();

        // Power Supply
        // IPowerSupply

        // Thermal Management
        // IHeatManagement

        // Systems
        // ICollection<ISystem>

        // Networks
        // ICollection<INetwork>

        public ShipSystem[] Systems;
        public MainComputer()
        {
            var powerProfiles = new Dictionary<string, PowerProfile>();
            _powerAllocator = new PowerAllocator(PowerModules, powerProfiles);
        }
    }
}
