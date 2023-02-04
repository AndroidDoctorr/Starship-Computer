using Assets.Scripts.Computer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Computer
{
    public enum DeviceStatus { Unresponsive, Disabled, Offline, Online, Maintenance }
    public class Device : MonoBehaviour
    {
        protected AudioSource _as;
        public Guid Id { get; protected set; }
        public string Name;
        public int Priority { get; protected set; }
        public int Port { get; protected set; }
        public UsageProfile UsageProfile { get; protected set; }
        public PowerProfile PowerProfile { get; protected set; }
        public DeviceStatus Status = DeviceStatus.Offline;
        public bool HasPower = false;
        public bool IsBroken = false;
        public bool IsInMaintenance = false;
        public Sprite Icon;
        protected bool SetPowerDraw(int priority, double level)
        {
            bool canSetPower = PowerProfile.SetPowerDraw(priority, level);
            if (canSetPower) return true;
            Debug.LogError($"Power Profile - {Name} - cannot set power to {level}");
            return false;
        }
        public void PowerDown(int priority)
        {
            Debug.Log($"Power Down Device: {GetType().Name}");

            bool canSetPower = PowerProfile.SetPowerDraw(priority, 0);
            if (!canSetPower)
            {
                Debug.LogError($"Permission denied - cannot deactivate: {GetType().Name}");
                return;
            }
            Status = DeviceStatus.Offline;
        }
        public void PowerUp(int priority)
        {
            Debug.Log($"Power Up Device: {GetType().Name}");

            bool canSetPower = PowerProfile.SetPowerDraw(priority, PowerProfile.MinPowerDraw);
            if (!canSetPower)
            {
                Debug.LogError($"Permission denied - cannot power: {GetType().Name}");
                return;
            }
            Status = DeviceStatus.Online;
        }
        
        protected void PlaySound(AudioClip clip)
        {
            if (clip == null) return;
            if (_as == null) return;
            _as.clip = clip;
            _as.PlayDelayed(0);
        }
    }
}
