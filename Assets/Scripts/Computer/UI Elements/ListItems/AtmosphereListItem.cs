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
    public class AtmosphereListItem : UIListItem
    {
        public TMP_Text Type;
        public TMP_Text Temperature;
        public TMP_Text Humidity;
        public TMP_Text Count;
        public override void Populate(ListItemData data)
        {
            if (data is not AtmosphereData)
            {
                Debug.LogError($"Data not formatted for Lighting Group item: {data.GetType().Name}");
                return;
            }

            AtmosphereData atmosData = data as AtmosphereData;

            Name.text = atmosData.Name;
            Type.text = atmosData.Type;
        }
    }
    public class AtmosphereData : ListItemData
    {
        public string Name;
        public string Type;
        public float Temperature;
        public float Humidity;
        public int Count;

        public AtmosphereData(AtmosphereGroup atmos)
        {
            if (atmos == null)
                return;

            Name = atmos.Name;
            Type = atmos.GetType().Name;
        }
    }
}
