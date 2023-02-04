using Assets.Scripts.Computer.Core.CoreModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Computer.Core
{
    public class ResourceAllocator : MonoBehaviour
    {
        // Module Panels
        public CircuitPanel<LogicModule>[] LogicPanels;
        public CircuitPanel<LearningModule>[] LearningPanels;
        public CircuitPanel<MemoryModule>[] MemoryPanels;
        public CircuitPanel<HybridModule>[] HybridPanels;

        // Called whenever modules are added or removed
        public delegate void ModuleChangeDelegate(Circuit circuit);
        public event ModuleChangeDelegate OnModuleChange;

        public IEnumerable<ILogicModule> LogicModules
        {
            get
            {
                IEnumerable<ILogicModule> logicModules =
                    LogicPanels.Select(p => p.Modules).SelectMany(m => m);
                IEnumerable<ILogicModule> hybridModules =
                    HybridPanels.Select(p => p.Modules).SelectMany(m => m);

                return logicModules.Concat(hybridModules);
            }
        }
        public IEnumerable<IDataModule> LearningModules
        {
            get
            {
                IEnumerable<IDataModule> learningModules =
                    LearningPanels.Select(p => p.Modules).SelectMany(m => m);
                IEnumerable<IDataModule> hybridModules =
                    HybridPanels.Select(p => p.Modules).SelectMany(m => m);

                return learningModules.Concat(hybridModules);
            }
        }
        public IEnumerable<IDataModule> MemoryModules
        {
            get
            {
                IEnumerable<IDataModule> memoryModules =
                    MemoryPanels.Select(p => p.Modules).SelectMany(m => m);
                IEnumerable<IDataModule> hybridModules =
                    HybridPanels.Select(p => p.Modules).SelectMany(m => m);

                return memoryModules.Concat(hybridModules);
            }
        }

        // Logic properties
        public decimal ClockSpeedTotal => LogicModules.Sum(s => s.ClockSpeed);
        public decimal ClockSpeedAcg => LogicModules.Average(s => s.ClockSpeed);
        public decimal BusSpeedTotal => LogicModules.Sum(s => s.BusSpeed);
        public decimal BusSpeedAvg => LogicModules.Average(s => s.BusSpeed);
        public decimal CacheSizeTotal => LogicModules.Sum(s => s.CacheSize);
        public decimal CacheSizeAvg => LogicModules.Average(s => s.CacheSize);
        public decimal Threads => LogicModules.Sum(s => s.Threads);

        // Learning properties
        public decimal LearningTotal => LearningModules.Sum(s => s.DataCapacity);
        public decimal LearningDataAvg => LearningModules.Average(s => s.DataCapacity);
        public decimal LearningIOCap => LearningModules.Sum(s => s.IOCapacity);
        public decimal LearningIOAvg => LearningModules.Average(s => s.IOCapacity);

        // Memory properties
        public decimal MemoryTotal => MemoryModules.Sum(s => s.DataCapacity);
        public decimal MemoryDataAvg => MemoryModules.Average(s => s.DataCapacity);
        public decimal MemoryIOCap => MemoryModules.Sum(s => s.IOCapacity);
        public decimal MemoryIOAvg => MemoryModules.Average(s => s.IOCapacity);

        private void OnEnable()
        {
            
        }
    }
}
