using Assets.Scripts.Computer.Core;
using Assets.Scripts.Computer.Systems.Environment.SubSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Computer.Systems.Environment
{
    public enum EnvironmentPropGroup { Lighting, Atmosphere }
    public class Environment : ShipSystem
    {
        public LightingGroup[] LightingGroups;
        public AtmosphereGroup[] AtmosphereGroups;

        // public override event ISystem.PropertyChangeDelegate OnPropertyChange;

        private void OnEnable()
        {
            // Set up average or other props??
        }

        public bool TurnOnLightingGroup(string name)
        {
            string formattedName = name.ToLower().Trim();
            LightingGroup lightingGroup = LightingGroups.FirstOrDefault(g => g.Name.ToLower().Trim() == formattedName);
            
            if (lightingGroup == null)
            {
                Debug.LogWarning($"Lighting Group \"{name}\" not found");
                return false;
            }

            lightingGroup.TurnOnAllLights(false);
            return true;
        }
        public bool TurnOffLightingGroup(string name)
        {
            string formattedName = name.ToLower().Trim();
            LightingGroup lightingGroup = LightingGroups.FirstOrDefault(g => g.Name.ToLower().Trim() == formattedName);
            
            if (lightingGroup == null)
            {
                Debug.LogWarning($"Lighting Group \"{name}\" not found");
                return false;
            }

            lightingGroup.TurnOffAllLights();
            return true;
        }
        public Device[] GetDevices()
        {
            List<Device> devices = new List<Device>();
            // Add devices from subsystems
            Array.ForEach(LightingGroups, s => devices.AddRange(s.GetDevices()));
            Array.ForEach(AtmosphereGroups, s => devices.AddRange(s.GetDevices()));

            return devices.ToArray();
        }

        private void UpdateLighting(string name, object value, params object[] parameters)
        {
            // OnPropertyChange(name, value, EnvironmentPropGroup.Lighting);
        }
        private void UpdateAtmosphere(string name, object value, params object[] parameters)
        {
            // OnPropertyChange(name, value, EnvironmentPropGroup.Atmosphere);
        }
    }
}
