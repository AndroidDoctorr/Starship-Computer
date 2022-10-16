using Assets.Scripts.Computer.Core.CoreModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Core
{
    public class ComputerCore : IComputerCore
    {
        public ICollection<ILearningModule> LearningModules { get; private set; }
        public ICollection<IMemoryModule> MemoryModules { get; private set; }
        public ICollection<IProcessingModule> ProcessingModules { get; private set; }

        private ResourceAllocator _resourceAllocator;

        public ComputerCore(
            ICollection<ILearningModule> learningModules,
            ICollection<IMemoryModule> memoryModules,
            ICollection<IProcessingModule> processingModules
        )
        {
            LearningModules = learningModules;
            MemoryModules = memoryModules;
            ProcessingModules = processingModules;
            _resourceAllocator = new ResourceAllocator(learningModules, memoryModules, processingModules);
        }
    }
}
