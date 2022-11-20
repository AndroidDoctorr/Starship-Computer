using Assets.Scripts.Computer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Computer
{
    public class Device : MonoBehaviour
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public int Priority { get; protected set; }
        public int Port { get; protected set; }
        public string PhysicalAddress { get; protected set; }
        public UsageProfile UsageProfile { get; protected set; }
        public PowerProfile PowerProfile { get; protected set; }
        public bool HasPower;
        protected bool SetPowerDraw(int priority, double level)
        {
            bool canSetPower = PowerProfile.SetPowerDraw(priority, level);
            if (canSetPower) return true;
            Debug.LogError($"Power Profile - {Name} - cannot set power to {level}");
            return false;
        }
        public void PowerDown(int priority)
        {
            Debug.Log($"Power Down UI: {GetType().Name}");

            HasPower = false;
            PowerProfile.SetPowerDraw(priority, 0);
        }
        public void PowerUp(int priority)
        {
            Debug.Log($"Power Up UI: {GetType().Name}");

            HasPower = true;
            PowerProfile.SetPowerDraw(priority, PowerProfile.MinPowerDraw);
        }
    }
}
