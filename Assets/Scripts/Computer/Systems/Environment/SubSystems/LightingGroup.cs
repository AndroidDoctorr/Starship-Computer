using Assets.Scripts.Computer.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Computer.Systems.Environment.SubSystems
{
    public enum LightingMode { Solid, Candle, Various }
    public class LightingGroup : SubSystem
    {
        public readonly static Color CandleColor = new Color(1, 0.6f, 0.25f);
        // Built in to Unity
        public readonly static float MaxIntensity = 8;

        public LightFixture[] LightFixtures;
        public bool BeginOn = false;
        public Color DefaultColor = Color.white;
        public float DefaultBrightness = 0.6f;
        public LightingMode LightingMode { get; private set; } = LightingMode.Solid;
        public int Count => LightFixtures.Length;
        public float Brightness { get; private set; }
        public Color Color { get; private set; }
        public bool IsOn { get; private set; }

        public override event ISystem.PropertyChangeDelegate OnPropertyChange;

        private void Start()
        {
            if (BeginOn) TurnOnAllLights(true);
        }
        public bool DisconnectLightFixture()
        {
            // Generic method for subsystems - ConnectDevice?
            // Or this makes use of it/extends it?
            OnPropertyChange("Devices", LightFixtures.Length);
            return true;
        }
        public bool ConnectLightFixture()
        {
            OnPropertyChange("Devices", LightFixtures.Length);
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
                    LightingMode = LightingMode.Solid;
                }
                fixture.TurnOn();
            }
            Brightness = DefaultBrightness;
            Color = DefaultColor;

            UpdateProperties();
        }
        public void TurnOffAllLights()
        {
            IsOn = false;
            foreach (LightFixture fixture in LightFixtures)
                fixture.TurnOff();
            Brightness = 0;
            Color = Color.black;

            UpdateProperties();
        }
        public void SetGroupColor(float hue, float saturation)
        {
            LightingMode = LightingMode.Solid;
            foreach (LightFixture fixture in LightFixtures)
                fixture.SetColor(hue, saturation);
            Color = Color.HSVToRGB(hue, saturation, 1);

            UpdateProperties();
        }
        public void SetGroupBrightness(float brightness)
        {
            foreach (LightFixture fixture in LightFixtures)
                fixture.SetBrightness(brightness);
            Brightness = brightness;

            UpdateProperties();
        }
        public void SetCandleMode()
        {
            LightingMode = LightingMode.Candle;
            if (!IsOn) TurnOnAllLights(false);
            foreach (LightFixture fixture in LightFixtures)
                fixture.SetCandleMode();
            Brightness = 1;
            Color = CandleColor;

            UpdateProperties();
        }
        public void SetRandomColor()
        {
            LightingMode = LightingMode.Solid;
            float hue = Random.Range(0f, 1f);
            float saturation = Random.Range(0.5f, 1f);

            foreach (LightFixture fixture in LightFixtures)
                fixture.SetColor(hue, saturation);
            Color = Color.HSVToRGB(hue, saturation, 1);

            UpdateProperties();
        }
        public void SetMultipleColors()
        {
            LightingMode = LightingMode.Various;
            foreach (LightFixture fixture in LightFixtures)
            {
                float hue = Random.Range(0f, 1f);
                float saturation = Random.Range(0.5f, 1f);

                fixture.SetColor(hue, saturation);
            }
            Color = Color.white;

            UpdateProperties();
        }
        public override Device[] GetSystemDevices()
        {
            List<Device> devices = new List<Device>();
            devices.AddRange(LightFixtures);
            return devices.ToArray();
        }

        private void UpdateProperties()
        {
            OnPropertyChange(nameof(LightingMode), LightingMode);
            OnPropertyChange(nameof(Brightness), Brightness);
            OnPropertyChange(nameof(Color), Color);
        }
    }
}
