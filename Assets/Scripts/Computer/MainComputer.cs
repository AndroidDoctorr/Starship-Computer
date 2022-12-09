using Assets.Scripts.Computer.Core;
using Assets.Scripts.Computer.Core.Configuration;
using Assets.Scripts.Computer.Core.CoreModules;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Computer
{
    public class MainComputer : MonoBehaviour
    {
        public static string DefaultConfigPath = "Assets/Resources/defaultconfig.json";

        private PowerAllocator _powerAllocator;
        // Computer Core
        public IComputerCore ComputerCore { get; private set; }
        public ICollection<IThermalModule> ThermalModules { get; private set; } = new List<IThermalModule>();
        public ICollection<IPowerModule> PowerModules { get; private set; } = new List<IPowerModule>();

        // Power Supply
        // IPowerSupply

        // Thermal Management
        // IHeatManagement

        // Networks
        public Dictionary<byte, Network> Networks;

        public ShipSystem[] Systems;
        public string CustomConfigPath;
        private void OnEnable()
        {
            Startup();
        }
        private void Startup() {
            // Startup procedure:
            LoadResources();    // Load physical resources
            MapNetwork();       // Map networks, systems, and devices
            AssignResources();  // Assign resources
            SystemsStart();     // Start systems
            // Type 0 Diagnostic = Startup
            // DiagnosticSweep(0); // Startup diagnostic sweep
        }
        private void LoadResources()
        {
            LoadPowerModules();
            LoadComputingModules();
        }
        private void LoadPowerModules()
        {
            var powerProfiles = new Dictionary<string, PowerProfile>();
            _powerAllocator = new PowerAllocator(PowerModules, powerProfiles);
        }
        private void LoadComputingModules()
        {
            // Get total Processing capacity
            // For each unit
            // - Check if active. Alert if not
            // - Get device properties, add to repo here for control
            // Get total Memory capacity
            // For each unit
            // - Check if active. Alert if not
            // - Get device properties, add to repo here for control
            // Get total Learning capacity
            // For each unit
            // - Check if active. Alert if not
            // - Get device properties, add to repo here for control
        }
        private void MapNetwork()
        {
            Config config = GetConfig();
        }
        private void AssignResources()
        {
            // For each Network in config - { networks: [], ... }
            // - Give each Network an address
            // - Add Network to some repo here???
            // - Go through system list

            // For each System in Network
            // - Attach system to network
            // - Mark system in Master Systems List as assigned to a network somehow
            // - Give each System an address
            // - Set priority of system within network
            // - Set system default properties
            // - Set default Usages
            // - What else???

            // For each Subsystem in System
            // - Give Subsystem an address
            // - Set priority of subsystem within system
            // - Set subsystem default properties
            // - Set default Usages
            // - Set up Devices
            // - Set up IODevices

            // For each Device in Subsystem
            // - Give each Device an address
            // - Set priority of device
            // - Set device default properties
            // - Set default Usages
            // - Turn on if on by default

            // For each IODevice in Subsystem
            // - Give each IODevice an address
            // - Set priority of IO device
            // - Set default UI
            //   OR show a default "no UI selected" graphic
            // - Turn on if on by default
            // - Set default UI settings???

            // Check Master Systems List - any unused? Error message
        }
        private void SystemsStart()
        {

        }
        private Config GetConfig()
        {
            string configPath = !string.IsNullOrWhiteSpace(CustomConfigPath) ?
                CustomConfigPath : DefaultConfigPath;
            string configString = File.ReadAllText(configPath);
            return JsonConvert.DeserializeObject<Config>(configString);
        }
    }
}
