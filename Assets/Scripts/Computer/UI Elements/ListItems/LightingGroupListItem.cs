using Assets.Scripts.Computer.Core;
using Assets.Scripts.Computer.Systems.Environment.SubSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

namespace Assets.Scripts.Computer.UI_Elements.ListItems
{
    public class LightingGroupListItem : UIListItem
    {
        public TMP_Text Type;
        public TMP_Text Mode;
        public TMP_Text Brightness;
        public TMP_Text Count;
        public Image ColorSample;
        public override void Populate(ListItemData data)
        {
            if (data is not LightingGroupData)
            {
                Debug.LogError($"Data not formatted for Lighting Group item: {data.GetType().Name}");
                return;
            }

            LightingGroupData lightData = data as LightingGroupData;

            Name.text = lightData.Name;
            Type.text = lightData.Type;
            Mode.text = lightData.Mode;
            Brightness.text = $"{lightData.Brightness:0.##}";
            Count.text = $"{lightData.Count:0.##}";
            ColorSample.color = new Color(lightData.R, lightData.G, lightData.B);
        }
        public override void ConnectSystem(SystemBase system)
        {
            if (system is not LightingGroup) return;
            LightingGroup lightingGroup = system as LightingGroup;

            Name.text = lightingGroup.Name;
            Type.text = lightingGroup.GetType().Name;
            Mode.text = $"{lightingGroup.LightingMode}";
            Brightness.text = $"{lightingGroup.Brightness:0.##}";
            Count.text = $"{lightingGroup.Count}";
            ColorSample.color = new Color(lightingGroup.Color.r, lightingGroup.Color.g, lightingGroup.Color.b);
            
            lightingGroup.OnPropertyChange += UpdateSystemProperty;
        }
        public void DisconnectSystem(SystemBase system)
        {
            if (system is not LightingGroup) return;
            LightingGroup lightingGroup = system as LightingGroup;
            lightingGroup.OnPropertyChange -= UpdateSystemProperty;
        }

        private void UpdateSystemProperty(string name, object newValue, params object[] parameters)
        {
            switch (name)
            {
                case nameof(LightingGroup.LightingMode):
                    Mode.text = newValue.ToString();
                    break;
                case nameof(LightingGroup.Brightness):
                    Brightness.text = $"{newValue:0.##}";
                    break;
                case nameof(LightingGroup.Color):
                    Color color = newValue is Color ? (Color) newValue : Color.white;
                    ColorSample.color = new Color(color.r, color.g, color.b);
                    break;
                case nameof(LightingGroup.Count):
                    Count.text = $"{newValue}";
                    break;
                default:
                    break;
            }
        }
    }


    public class LightingGroupData : ListItemData
    {
        public string Name;
        public string Type;
        public string Mode;
        public int Count;
        public float Brightness;
        public float R;
        public float G;
        public float B;

        public LightingGroupData(LightingGroup lights)
        {
            if (lights == null)
                return;

            Name = lights.Name;
            Type = lights.GetType().Name;
            Mode = lights.LightingMode.ToString();
            Count = lights.LightFixtures.Count();
            Brightness = lights.Brightness;
            R = lights.Color.r;
            G = lights.Color.g;
            B = lights.Color.b;
        }
    }
}
