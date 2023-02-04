using Assets.Scripts.Computer.Core;
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
    public class SubsystemListItem : UIListItem
    {
        public TMP_Text Type;
        public TMP_Text Stat1Label;
        public TMP_Text Stat2Label;
        public TMP_Text Stat3Label;
        public TMP_Text Stat1Value;
        public TMP_Text Stat2Value;
        public TMP_Text Stat3Value;
        public override void Populate(ListItemData data)
        {
            if (data is not SubsystemData)
            {
                Debug.LogError($"Data not formatted for SubSystem item: {data.GetType().Name}");
                return;
            }

            SubsystemData systemData = data as SubsystemData;

            Name.text = systemData.Name;
            Type.text = systemData.Type;
        }
    }
    public class SubsystemData : ListItemData
    {
        public string Name;
        public string Type;

        public SubsystemData(SubSystem subsystem)
        {
            if (subsystem == null)
                return;

            Name = subsystem.Name;
            Type = subsystem.GetType().Name;
        }
    }
}
