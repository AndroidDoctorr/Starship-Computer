using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Computer.Systems.Environment.SubSystems
{
    public class LightingGroup : SubSystem
    {
        public LightFixture[] LightFixtures;
        public bool BeginOn = false;
        public Color DefaultColor = Color.white;
        public bool IsOn { get; private set; }

        private void Start()
        {
            if (BeginOn) TurnOnAllLights();
        }
        public bool DisconnectLightFixture()
        {
            // Generic method for subsystems - ConnectDevice?
            // Or this makes use of it/extends it?
            return true;
        }
        public bool ConnectLightFixture()
        {
            return true;
        }
        public void TurnOnAllLights()
        {
            IsOn = true;
            foreach (LightFixture fixture in LightFixtures)
                fixture.TurnOn();
        }
        public void TurnOffAllLights()
        {
            IsOn = false;
            foreach (LightFixture fixture in LightFixtures)
                fixture.TurnOff();
        }
        public void SetGroupColor(float hue, float saturation)
        {
            foreach (LightFixture fixture in LightFixtures)
                fixture.SetColor(hue, saturation);
        }
        public void SetGroupBrightness(float brightness)
        {
            foreach (LightFixture fixture in LightFixtures)
                fixture.SetBrightness(brightness);
        }
    }
}
