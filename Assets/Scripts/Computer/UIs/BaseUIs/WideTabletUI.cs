using Assets.Scripts.Computer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.UIs.BaseUIs
{
    public class WideTabletUI : GenericUI
    {
        public override SystemBase System { get { return null; } }
        public WideTabletUI()
        {
            Type = ConsoleType.WideTablet;
        }
    }
}
