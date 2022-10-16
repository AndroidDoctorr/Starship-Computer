using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Core.CoreModules
{
    public enum ProcessingSocketType { D1, Q1, D2, Q2 }
    public interface IProcessingModule
    {
        // Physical socket compatibility
        public ProcessingSocketType SocketType { get; }
        // Number of processing threads
        public int Threads { get; }
        // Calculations per second
        public decimal ClockSpeed { get; }
        // Data transfer rate between processor and socket (B/s)
        public decimal BusSpeed { get; }
        // Transfer buffer size (B)
        public decimal CacheSize { get; }
        // Coefficients used to calculate the thermal profile
        public decimal[] ThermalCoefficients { get; }
    }
}
