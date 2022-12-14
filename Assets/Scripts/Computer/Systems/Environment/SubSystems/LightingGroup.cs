using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Computer.Systems.Environment.SubSystems
{
    public class LightingGroup : SubSystem
    {
        // Built in to Unity
        public readonly static float MaxIntensity = 8;

        public LightFixture[] LightFixtures;
        public bool BeginOn = false;
        public Color DefaultColor = Color.white;
        public float DefaultBrightness = 0.6f;
        public bool IsOn { get; private set; }

        private void Start()
        {
            if (BeginOn) TurnOnAllLights(true);
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
        public void TurnOnAllLights(bool doReset)
        {
            IsOn = true;
            foreach (LightFixture fixture in LightFixtures)
            {
                Color.RGBToHSV(DefaultColor, out float h, out float s, out float v);
                if (doReset)
                {
                    fixture.SetColor(h, s);
                    fixture.SetBrightness(DefaultBrightness);
                }
                fixture.TurnOn();
            }
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
        public void SetCandleMode()
        {
            if (!IsOn) TurnOnAllLights(false);
            foreach (LightFixture fixture in LightFixtures)
                fixture.SetCandleMode();
        }
        public void SetRandomColor()
        {
            float hue = Random.Range(0f, 1f);
            float saturation = Random.Range(0.5f, 1f);

            foreach (LightFixture fixture in LightFixtures)
                fixture.SetColor(hue, saturation);
        }
        public void SetMultipleColors()
        {
            foreach (LightFixture fixture in LightFixtures)
            {
                float hue = Random.Range(0f, 1f);
                float saturation = Random.Range(0.5f, 1f);

                fixture.SetColor(hue, saturation);
            }
        }
    }
}
