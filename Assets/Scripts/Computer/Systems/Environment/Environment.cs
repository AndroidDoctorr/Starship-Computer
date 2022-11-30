using Assets.Scripts.Computer.Systems.Environment.SubSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Computer.Systems.Environment
{
    public class Environment : ShipSystem
    {
        public LightingGroup[] LightingGroups;
        public AtmosphereGroup[] AtmosphereGroups;

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
    }
}
