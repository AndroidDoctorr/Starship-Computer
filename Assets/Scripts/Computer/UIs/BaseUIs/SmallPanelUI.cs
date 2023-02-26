using Assets.Scripts.Computer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.UIs.BaseUIs
{
    public class SmallPanelUI : GenericUI
    {
        public override SystemBase System { get { return null; } }
        public SmallPanelUI()
        {
            Type = ConsoleType.SmallPanel;
        }
    }
}
