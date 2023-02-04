using Assets.Scripts.Computer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Systems.Warp_Core
{
    public class DilithiumMatrix : SubSystem
    {
        // TODO: Some measure of capacity - heat distribution or something?
        public double Capacity => 10;
        // 0 - 1, % matrix usage
        public double Usage => 0.5;

        // TODO: Usage => Reaction.Temp (go from 0 to 1, but approach asymptotically
        public double Variance => Usage / Capacity;
    }
}
