using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Core.CoreModules
{
    public interface ILogicModule : IModule
    {
        // Number of processing threads
        public int Threads { get; }
        // Calculations per second (GHz)
        public decimal ClockSpeed { get; }
        // Transfer buffer size (GB)
        public decimal CacheSize { get; }
    }
}
