using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Core.Configuration
{
    [Serializable]
    public class IODeviceConfig : DeviceConfig
    {
        public string DefaultUI;
        public ConsoleType ConsoleType;
    }
}
