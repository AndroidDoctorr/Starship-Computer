using Assets.Scripts.Computer.Systems.Environment.SubSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Computer.UI_Elements.ListItems
{
    public class LightingGroupListItem : UIListItem
    {
        public TMP_Text Type;
        public TMP_Text Mode;
        public TMP_Text Brightness;
        public TMP_Text Count;
        public Image Color;
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
            Color.color = new Color(lightData.R, lightData.G, lightData.B);
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
