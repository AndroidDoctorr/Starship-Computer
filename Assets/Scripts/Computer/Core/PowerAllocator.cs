using Assets.Scripts.Computer.Core.CoreModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Computer.Core
{
    internal class PowerAllocator
    {
        public Dictionary<Guid, IPowerModule> PowerModules { get; private set; }
        public Dictionary<Guid, PowerProfile> PowerProfiles { get; private set; }
        public PowerAllocator(
            ICollection<IPowerModule> powerModules,
            Dictionary<string, PowerProfile> powerProfiles
        )
        {
            foreach (IPowerModule powerModule in powerModules)
                PowerModules.Add(powerModule.Id, powerModule);
            foreach (KeyValuePair<string, PowerProfile> kvp in powerProfiles)
            {
                PowerProfile profile = kvp.Value;
                string id = kvp.Key;
                PowerProfiles.Add(Guid.Parse(id), profile);
            }
        }

        public bool AddPowerModule(IPowerModule powerModule)
        {
            if (powerModule == null) return false;
            PowerModules.Add(powerModule.Id, powerModule);
            return true;
        }
        public bool AddPowerProfile(PowerProfile powerProfile)
        {
            if (powerProfile == null) return false;
            PowerProfiles.Add(powerProfile.Id, powerProfile);
            return true;
        }
        public bool DisablePowerModule(Guid id)
        {
            if (!PowerModules.ContainsKey(id))
            {
                Debug.LogError($"Cannot disable power module (not found): {id}");
                return false;
            }
            PowerModules[id].Disable();
            return true;
        }
        public bool RemovePowerModule(Guid id)
        {
            if (!PowerModules.ContainsKey(id))
            {
                Debug.LogError($"Cannot remove power module (not found): {id}");
                return false;
            }
            PowerModules.Remove(id);
            return true;
        }
        public bool RevokePowerProfile(Guid id)
        {
            if (!PowerProfiles.ContainsKey(id))
            {
                Debug.LogError($"Cannot revoke power profile (not found): {id}");
                return false;
            }
            PowerProfiles.Remove(id);
            return true;
        }
    }
}
