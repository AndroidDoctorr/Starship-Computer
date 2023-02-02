﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Core.CoreModules
{
    public enum LearningSocketType { N1, D1, N2, D2, }
    public interface ILearningModule
    {
        public Guid Id { get; }
        // Physical socket compatibility
        public LearningSocketType Type { get; }
        // Maximum storage capacity (TB/kQ)
        public decimal DataCapacity { get; }
        // Maximum transfer speed (TB/s)
        public decimal IOCapacity { get; }
        // Coefficients used to calculate the thermal profile
        public decimal[] ThermalCoefficients { get; }
    }
}
