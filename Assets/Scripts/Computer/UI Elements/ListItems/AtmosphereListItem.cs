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
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

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
            Temperature.text = $"{atmosData.Temperature:0.##}";
            Humidity.text = $"{atmosData.Humidity:0.##}";
            Count.text = atmosData.Count.ToString();
        }
        public override void ConnectSystem(SystemBase system)
        {
            if (system is not AtmosphereGroup) return;
            AtmosphereGroup atmoGroup = system as AtmosphereGroup;

            Name.text = atmoGroup.Name;
            Type.text = atmoGroup.GetType().Name;
            Temperature.text = $"{atmoGroup.Temperature:0.##}";
            Humidity.text = $"{atmoGroup.Humidity:0.##}";
            Count.text = atmoGroup.Count.ToString();

            atmoGroup.OnPropertyChange += UpdateSystemProperty;
        }
        public void DisconnectSystem(SystemBase system)
        {
            if (system is not AtmosphereGroup) return;
            AtmosphereGroup atmoGroup = system as AtmosphereGroup;
            atmoGroup.OnPropertyChange -= UpdateSystemProperty;
        }

        private void UpdateSystemProperty(string propertyName, object newValue, params object[] parameters)
        {

        }
    }


    public class AtmosphereData : ListItemData
    {
        public string Name;
        public string Type;
        public double Temperature;
        public double Humidity;
        public int Count;

        public AtmosphereData(AtmosphereGroup atmos)
        {
            if (atmos == null)
                return;

            Name = atmos.Name;
            Type = atmos.GetType().Name;
            Temperature = atmos.Temperature;
            Humidity = atmos.Humidity;
            Count = atmos.GetDevices().Count();
        }
    }
}
