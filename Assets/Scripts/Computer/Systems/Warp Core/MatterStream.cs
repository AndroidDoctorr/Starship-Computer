using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Assets.Scripts.Computer.Systems.Warp_Core
{
    public class MatterStream
    {
        // Mass flow rate (~1 g/s is typical?)
        public double FlowRate { get; set; }
        // Velocity at the injector
        public double vInitial { get; set; }
        // Velocity at the reactor
        public double vFinal { get; set; }
        // Confinement - radius that contains 1 sigma of plasma concentration
        public double SigmaRadius { get; set; }
    }
}
