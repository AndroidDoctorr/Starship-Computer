using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Computer.UI_Elements.ListItems
{
    public class SubsystemListItem : UIListItem
    {
        public Text Id;
        public Text Name;
        public override void Populate(ListItemData data)
        {
            if (data is not SubsystemData)
            {
                Debug.LogError($"Data not formatted for SubSystem List: {data.GetType().Name}");
                return;
            }

            SubsystemData systemData = data as SubsystemData;

            Id.text = systemData.Id.ToString();
            Name.text = systemData.Name;
        }
    }
    public class SubsystemData : ListItemData
    {
        public Guid Id;
        public string Name;

        public SubsystemData(SubSystem subsystem)
        {
            if (subsystem == null)
                return;

            Id = subsystem.Id;
            Name = subsystem.Name;
        }
    }
}
