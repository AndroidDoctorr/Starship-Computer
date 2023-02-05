using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Core.CoreModules
{
    public enum HybridSocketType { QX1, QX2, NX1, NQX1 }
    public class HybridModule : Circuit, ILogicModule, IDataModule
    {
        // Physical socket compatibility
        public HybridSocketType SocketType;
        // Number of processing threads
        public int Threads { get; protected set; }
        // Calculations per second (GHz)
        public decimal ClockSpeed { get; protected set; }
        // Data transfer rate between processor and socket (GHz)
        public decimal BusSpeed { get; protected set; }
        // Transfer buffer size (GB)
        public decimal CacheSize { get; protected set; }
        // Coefficients used to calculate the thermal profile
        public decimal[] ThermalCoefficients { get; protected set; }
        // Maximum storage capacity (TB/kQ)
        public decimal DataCapacity { get; protected set; }

        public decimal PowerCap { get; protected set; }
    }
}
