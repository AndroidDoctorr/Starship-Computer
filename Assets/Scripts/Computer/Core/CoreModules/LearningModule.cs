using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Core.CoreModules
{
    public enum LearningSocketType { N1, D1, N2, D2, }
    public class LearningModule : Circuit, IDataModule
    {
        // Physical socket compatibility
        public LearningSocketType SocketType;
        // Maximum storage capacity (TB/kQ)
        public decimal DataCapacity { get; protected set; }
        // Maximum transfer speed (TB/s)
        public decimal BusSpeed { get; protected set; }
        // Coefficients used to calculate the thermal profile
        public decimal[] ThermalCoefficients { get; protected set; }

        public decimal CacheSize { get; protected set; }

        public decimal PowerCap { get; protected set; }
    }
}
