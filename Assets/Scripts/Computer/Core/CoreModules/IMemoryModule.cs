using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Core.CoreModules
{
    public enum MemorySocketType { D1, N1, D2, N2 }
    public interface IMemoryModule
    {
        // Physical socket compatibility
        public MemorySocketType Type { get; }
        // Maximum storage capacity (TB/kQ)
        public decimal DataCapacity { get; }
        // Maximum transfer speed (TB/s)
        public decimal IOCapacity { get; }
        // Coefficients used to calculate the thermal profile
        public decimal[] ThermalCoefficients { get; }
    }
}
