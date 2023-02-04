using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Core.CoreModules
{
    public enum MemorySocketType { D1, N1, D2, N2 }
    public class MemoryModule : Circuit, IDataModule
    {
        // Physical socket compatibility
        public MemorySocketType SocketType;
        // Maximum storage capacity (TB/kQ)
        public decimal DataCapacity { get; protected set; }
        // Maximum transfer speed (TB/s)
        public decimal IOCapacity { get; protected set; }
        // Coefficients used to calculate the thermal profile
        public decimal[] ThermalCoefficients { get; protected set; }
    }
}
