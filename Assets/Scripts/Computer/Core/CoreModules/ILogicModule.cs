using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Core.CoreModules
{
    public enum ProcessingSocketType { D1, Q1, D2, Q2, H }
    public interface ILogicModule : IModule
    {
        // Physical socket compatibility
        public ProcessingSocketType SocketType { get; }
        // Number of processing threads
        public int Threads { get; }
        // Calculations per second (GHz)
        public decimal ClockSpeed { get; }
        // Transfer buffer size (GB)
        public decimal CacheSize { get; }
    }
}
