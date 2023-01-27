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
    public class DeviceListItem : UIListItem
    {
        public TMP_Text Id;
        public TMP_Text Type;
        public TMP_Text Priority;
        public TMP_Text Status;
        public TMP_Text Stat1Label;
        public TMP_Text Stat2Label;
        public TMP_Text Stat1Value;
        public TMP_Text Stat2Value;
        public Image IconImage;
        public Sprite Icon;
        public override void Populate(ListItemData data)
        {
            if (data is not DeviceData)
            {
                Debug.LogError($"Data not formatted for Device List: {data.GetType().Name}");
                return;
            }

            DeviceData deviceData = data as DeviceData;

            Id.text = deviceData.Id.ToString();
            Name.text = deviceData.Name;
            Priority.text = deviceData.Priority.ToString();
            Status.text = deviceData.Status.ToString();
            Icon = deviceData.Icon;
        }
    }
    public class DeviceData : ListItemData
    {
        public Guid Id;
        public string Name;
        public int Priority;
        public DeviceStatus Status;
        public Sprite Icon;

        public DeviceData(Device device)
        {
            if (device == null)
                return;

            Id = device.Id;
            Name = device.Name;
            Priority = device.Priority;
            Icon = device.Icon;
            Status =
                device.HasPower ?
                    device.IsInMaintenance ?
                        DeviceStatus.Maintenance :
                    device.IsBroken ?
                        DeviceStatus.Disabled :
                    DeviceStatus.Online :
                DeviceStatus.Offline;
        }
    }
}
