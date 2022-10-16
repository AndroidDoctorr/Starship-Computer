using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Core.CoreModules
{
    public enum ThermalModuleType { S1, S2, S3, L1, L2 }
    public interface IThermalModule
    {
        public ThermalModuleType Type { get; }
        // Power draw in W
        public decimal Power { get; }
        // Thermal draw in W
        public decimal ThermalDraw { get; }
        // Coefficients used to calculate the thermal profile
        public decimal[] ThermalCoefficients { get; }
    }
}
