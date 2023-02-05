using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Core.CoreModules
{
    public interface IModule
    {
        // Data transfer rate between module and socket (GHz)
        public decimal BusSpeed { get; }
        // Maximum power input
        public decimal PowerCap { get; }
        // Coefficients used to calculate the thermal profile
        public decimal[] ThermalCoefficients { get; }
    }
}
