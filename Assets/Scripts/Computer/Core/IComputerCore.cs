using Assets.Scripts.Computer.Core.CoreModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer
{
    public interface IComputerCore
    {
        ICollection<ILearningModule> LearningModules { get; }
        ICollection<IMemoryModule> MemoryModules { get; }
        ICollection<IProcessingModule> ProcessingModules { get; }
    }
}
