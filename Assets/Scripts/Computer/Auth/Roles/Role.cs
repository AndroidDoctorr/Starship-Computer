using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Identity
{
    public class Role
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // Role Definition
        public int DefaultPriority { get; }
        // Whitelist
        //   Networks
        //   - Systems
        //   -- Subsystems
        //   --- Devices

        // Blacklist
        //   Networks
        //   - Systems
        //   -- Subsystems
        //   --- Devices
    }
}
