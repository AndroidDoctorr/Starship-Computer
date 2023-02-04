using Assets.Scripts.Computer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Core
{
    public class SystemGroup
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public int Priority { get; private set; }
        public UsageProfile UsageProfile { get; }
        public Dictionary<byte, ShipSystem> Systems { get; set; }
    }
}
