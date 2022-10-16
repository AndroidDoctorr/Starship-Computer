using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Computer.Core
{
    public class PowerProfile
    {
        public Guid Id { get; }
        public string Name { get; }
        public int Priority { get; protected set; }
        public bool IsEnabled { get; protected set; } = false;
        public double PowerDraw { get; protected set; }
        public double MaxPowerDraw { get; set; }
        public double MinPowerDraw { get; set; }

        public PowerProfile(
            int priority,
            Guid id,
            string name,
            double minPowerDraw,
            double maxPowerDraw
        )
        {
            Id = id;
            Name = name;
            Priority = priority;
            PowerDraw = minPowerDraw;
            MaxPowerDraw = maxPowerDraw;
            MinPowerDraw = minPowerDraw;
        }

        public bool Disable(int priority)
        {
            Debug.Log($"Disable Usage Profile: {Id}");
            if (priority > Priority)
            {
                Debug.LogWarning($"Cannot Disable Usage Profile: {Id} - Access Denied");
                return false;
            }
            IsEnabled = false;
            return true;
        }
        public bool Enable(int priority)
        {
            Debug.Log($"Enable Usage Profile: {Id}");
            if (priority > Priority)
            {
                Debug.LogWarning($"Cannot Enable Usage Profile: {Id} - Access Denied");
                return false;
            }

            IsEnabled = true;

            PowerDraw = MinPowerDraw;
            return true;
        }
        public bool SetPriority(int priority, int newPriority)
        {
            Debug.Log($"Set Usage Profile Priority: {Id}");
            if (priority > 1)
            {
                Debug.LogWarning($"Cannot Set Usage Profile Priority: {Id} - Access Denied");
                return false;
            }
            Priority = newPriority;
            return true;
        }
        public bool SetPowerDraw(int priority, double level)
        {
            Debug.Log($"Set Usage Profile Power Draw: {Id}");
            if (priority > Priority)
            {
                Debug.LogWarning($"Cannot Set Usage Profile Power Draw: {Id} - Access denied");
                return false;
            }
            if (level < MinPowerDraw)
            {
                Debug.LogWarning($"Cannot Set Power Draw below {MinPowerDraw}");
                return false;
            }
            if (level > MaxPowerDraw)
            {
                Debug.LogWarning($"Cannot Set Power Draw usage above {MaxPowerDraw}");
                return false;
            }

            PowerDraw = level;
            return true;
        }
    }
}
