using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Systems.Environment.SubSystems
{
    public class LightingGroup : SubSystem
    {
        public LightFixture[] LightFixtures;

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
            foreach (LightFixture fixture in LightFixtures)
                fixture.TurnOn();
        }
        public void TurnOffAllLights()
        {
            foreach (LightFixture fixture in LightFixtures)
                fixture.TurnOff();
        }
        public void SetGroupColor(float hue)
        {
            foreach (LightFixture fixture in LightFixtures)
                fixture.SetColor(hue);
        }
        public void SetGroupBrightness(float brightness)
        {
            foreach (LightFixture fixture in LightFixtures)
                fixture.SetBrightness(brightness);
        }
    }
}
