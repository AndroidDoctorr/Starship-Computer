using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Core.CoreModules
{
    public class LogicModule : Circuit, ILogicModule
    {
        // Physical socket compatibility
        public ProcessingSocketType SocketType { get; protected set; }
        // Number of processing threads
        public int Threads { get; protected set; }
        // Calculations per second (GHz)
        public decimal ClockSpeed { get; protected set; }
        // Data transfer rate between processor and socket (GHz)
        public decimal BusSpeed { get; protected set; }
        // Temprorary transfer storage (TB/kQ)
        public decimal Buffer { get; protected set; }
        // Transfer buffer size (GB)
        public decimal CacheSize { get; protected set; }
        // Coefficients used to calculate the thermal profile
        public decimal[] ThermalCoefficients { get; protected set; }

        public decimal PowerCap { get; protected set; }
    }
}
