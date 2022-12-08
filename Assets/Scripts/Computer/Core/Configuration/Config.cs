using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Core.Configuration
{
    [Serializable]
    public class Config
    {
        // Everything here must be serializable - parsed from JSON
        IEnumerable<NetworkConfig> Networks;
    }
}
