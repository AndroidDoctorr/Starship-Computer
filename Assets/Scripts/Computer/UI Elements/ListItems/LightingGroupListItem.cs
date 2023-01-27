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
        }
    }
    public class LightingGroupData : ListItemData
    {
        public string Name;
        public string Type;

        public LightingGroupData(LightingGroup subsystem)
        {
            if (subsystem == null)
                return;

            Name = subsystem.Name;
            Type = subsystem.GetType().Name;
        }
    }
}
