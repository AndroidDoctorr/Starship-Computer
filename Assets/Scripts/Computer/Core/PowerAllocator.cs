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
    public class PowerAllocator
    {
        public double TotalCapacity;
        public Dictionary<Guid, IPowerModule> PowerModules { get; private set; }
        public Dictionary<Guid, PowerProfile> PowerProfiles { get; private set; }
        public PowerAllocator(
            ICollection<IPowerModule> powerModules,
            Dictionary<string, PowerProfile> powerProfiles
        )
        {
            SetUpPowerModules(powerModules);
            SetUpProfiles(powerProfiles);
        }
        private void SetUpPowerModules(ICollection<IPowerModule> powerModules)
        {
            TotalCapacity = 0;
            foreach (IPowerModule powerModule in powerModules)
            {
                if (powerModule.PingAsync().Result)
                {
                    PowerModules.Add(powerModule.Id, powerModule);
                    TotalCapacity += powerModule.MaxPower;
                }
                else
                    Debug.LogError($"Startup: Power Module {powerModule.Id} inactive");
            }
        }
        private void SetUpProfiles(Dictionary<string, PowerProfile> powerProfiles)
        {
            double minimumUsage = 0;
            double maximumUsage = 0;
            foreach (KeyValuePair<string, PowerProfile> kvp in powerProfiles)
            {
                PowerProfile profile = kvp.Value;
                Guid id = Guid.Parse(kvp.Key);
                PowerProfiles.Add(id, profile);
                minimumUsage += profile.MinPowerDraw;
                maximumUsage += profile.MaxPowerDraw;
            }
            if (maximumUsage > TotalCapacity)
            {
                Debug.LogWarning($"Power Allocation - Warning: System power does not meet minimum requirements for all sytems");
            }
            if (minimumUsage > TotalCapacity)
            {
                Debug.LogWarning("");
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
