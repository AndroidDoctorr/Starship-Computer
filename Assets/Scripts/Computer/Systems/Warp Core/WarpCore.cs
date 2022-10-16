using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Systems.Warp_Core
{
    public class WarpCore : ShipSystem
    {
        public AntimatterReaction Reaction;
        // Subsystems


        // Properties
        public double Power => Reaction.TotalPower;
        
        // Methods
    }
}
