using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Core.CoreModules
{
    public enum PowerSocketType { S1, SS1, S2, SS2 }
    public interface IPowerModule
    {
        public Guid Id { get; }
        public PowerSocketType Type { get; }
        // Power in W
        public decimal Power { get; }
        // Coefficients used to calculate the thermal profile
        public decimal[] ThermalCoefficients { get; }
        public void Enable();
        public void Disable();
    }
}
