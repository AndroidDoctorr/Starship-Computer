﻿using System;
using Assets.Scripts.Computer.Devices.CoreDevices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Computer.Core.CoreModules
{
    public class CircuitPanel : MonoBehaviour
    {
        private Dictionary<string, IModule> _modules = new Dictionary<string, IModule>();

        public List<CircuitSlot> Slots;
        public Dictionary<string, DeviceStatus> ModuleStatus =>
            (Dictionary<string, DeviceStatus>) _modules.Select(m =>
                new KeyValuePair<string, DeviceStatus>(m.Key, ((Circuit) m.Value).Status));

        public bool DoDebug = false;

        public IEnumerable<IModule> Modules { get { return _modules.Select(m => m.Value); } }

        // Called whenever modules are added or removed
        public delegate void ModuleChangeDelegate(bool isConnected, string slotName, Circuit circuit);
        public event ModuleChangeDelegate OnModuleChange;

        private void OnEnable()
        {
            ConnectSlots();
        }
        private void OnDestroy()
        {
            DisconnectSlots();
        }


        public void ResetPanel()
        {
            DisconnectSlots();
            ConnectSlots();
        }
        public void ShutDownPanel()
        {
            DisconnectSlots();
        }
        private void DisconnectSlots()
        {
            // Empty dictionary
            _modules = new Dictionary<string, IModule>();
            // Unsubscribe from connect events
            foreach (CircuitSlot slot in Slots)
                DisconnectSlot(slot);
        }
        private void ConnectSlots()
        {
            foreach (CircuitSlot slot in Slots)
                ConnectSlot(slot);
        }
        private void ConnectSlot(CircuitSlot slot)
        {
            // Subscribe to slot connection
            slot.OnConnect += UpdateModule;
            // Add connected modules to dictionary
            if (!_modules.ContainsKey(slot.Name))
                _modules.Add(slot.Name, slot.ConnectedCircuit.GetComponent<IModule>());
        }
        private void DisconnectSlot(CircuitSlot slot)
        {
            // Unubscribe from slot connection
            slot.OnConnect -= UpdateModule;
        }
        private void UpdateModule(bool isConnected, string slotName, Circuit circuit)
        {
            if (!isConnected || circuit == default)
                DisconnectModule(slotName);
            else
                ConnectModule(slotName, circuit);
        }
        private void DisconnectModule(string slotName)
        {
            if (_modules.ContainsKey(slotName))
                _modules.Remove(slotName);
            else
                Debug.LogWarning("Unregistered Module disconnected from Panel");

            OnModuleChange(false, slotName, default);
        }
        private void ConnectModule(string slotName, Circuit circuit)
        {
            // Add or update
            IModule module = circuit.GetComponent<IModule>();
            if (_modules.ContainsKey(slotName))
                _modules[slotName] = module;
            else _modules.Add(slotName, module);

            OnModuleChange(true, slotName, circuit);
        }
    }
}
