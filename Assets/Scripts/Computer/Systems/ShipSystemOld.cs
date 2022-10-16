using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class ShipSystemOld : MonoBehaviour
    {
        public GenericUI UI;
        public bool HasPower { get; protected set; } = false;
        public bool IsEnabled { get; protected set; } = false;
        public bool IsLowPowerMode { get; protected set; } = false;
        public float PowerDraw { get; protected set; } = 0;
        public float MaxPowerDraw { get; protected set; } = 100;

        public delegate void PowerChange(ShipSystemOld system);
        public event PowerChange OnPowerChange;

        public virtual void SetPowerLevel(float level)
        {
            if (!IsEnabled) return;
            if (level > 1) level = 1;
            if (level < 0) level = 0;
            if (IsLowPowerMode && level > 0.25f) level = 0.25f;
            PowerDraw = level * MaxPowerDraw;
        }
        public virtual void SetLowPowerModeActive(bool isActive)
        {
            IsLowPowerMode = isActive;
            if (IsLowPowerMode)
                PowerDraw = 0.25f * MaxPowerDraw;
            else
                PowerDraw = 0.5f * MaxPowerDraw;
            OnPowerChange(this);
        }
        public virtual void Disable()
        {
            PowerDraw = 0;
            IsLowPowerMode = false;
            IsEnabled = false;
            OnPowerChange(this);

            if (UI != null) UI.Disable();
        }
        public virtual void Enable()
        {
            Debug.Log($"Enabling system: {GetType().Name}");
            IsEnabled = true;
            SetLowPowerModeActive(false);
            if (!HasPower) return;
            if (UI != null) UI.Enable();
            PowerDraw = 0.5f * MaxPowerDraw;
            OnPowerChange(this);
        }
        public virtual void PowerDown()
        {
            PowerDraw = 0;
            IsLowPowerMode = false;
            IsEnabled = false;
            HasPower = false;

            if (UI != null) UI.PowerDown();
        }
        public virtual void PowerUp()
        {
            Debug.Log($"Powering up system: {GetType().Name}");
            HasPower = true;
            if (IsEnabled) Enable();
            else Disable();

            if (UI != null) UI.PowerUp();
        }
        public void SetRedAlert(bool isRedAlert)
        {
            if (UI != null) UI.SetRedAlert(isRedAlert);
        }
    }
}
