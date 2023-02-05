using Assets.Scripts.Computer.Core.CoreModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace Assets.Scripts.Computer.Core
{
    public class ResourceAllocator : CoreSystem
    {
        private IEnumerable<ILogicModule> _logicModules;
        private IEnumerable<IDataModule> _learningModules;
        private IEnumerable<IDataModule> _memoryModules;
        private IEnumerable<IModule> _hybridModules;

        // Module Panels
        public CircuitPanel[] LogicPanels;
        public CircuitPanel[] LearningPanels;
        public CircuitPanel[] MemoryPanels;
        public CircuitPanel[] HybridPanels;

        // Called whenever modules are added or removed
        // public delegate void ModuleChangeDelegate(IModule module);
        // public event ModuleChangeDelegate OnModuleChange;
        public override event ISystem.PropertyChangeDelegate OnPropertyChange;

        public IEnumerable<ILogicModule> LogicModules =>
            _logicModules.Concat((IEnumerable<ILogicModule>) _hybridModules);
        public IEnumerable<IDataModule> LearningModules =>
            _learningModules.Concat((IEnumerable<IDataModule>) _hybridModules);
        public IEnumerable<IDataModule> MemoryModules =>
            _memoryModules.Concat((IEnumerable<IDataModule>) _hybridModules);

        // Logic properties
        public int LogicModuleCount => LogicModules.Count();
        public decimal ClockSpeedTotal => LogicModules.Sum(s => s.ClockSpeed);
        public decimal ClockSpeedAvg => LogicModules.Average(s => s.ClockSpeed);
        public decimal LogicBusSpeedTotal => LogicModules.Sum(s => s.BusSpeed);
        public decimal LogicBusSpeedAvg => LogicModules.Average(s => s.BusSpeed);
        public decimal LogicCacheCap => LogicModules.Sum(s => s.CacheSize);
        public decimal LogicCacheAvg => LogicModules.Average(s => s.CacheSize);
        public decimal Threads => LogicModules.Sum(s => s.Threads);
        public decimal LogicPowerCap => LogicModules.Sum(s => s.PowerCap);
        public decimal LogicPowerAvg => LogicModules.Average(s => s.PowerCap);
        public decimal LogicDCap => LogicModules
            .Where(s => s.SocketType == ProcessingSocketType.D1 ||
                s.SocketType == ProcessingSocketType.D2)
            .Sum(s => s.ClockSpeed);
        public decimal LogicQCap => LogicModules
            .Where(s => s.SocketType == ProcessingSocketType.Q1 ||
                s.SocketType == ProcessingSocketType.Q2)
            .Sum(s => s.ClockSpeed);
        public decimal LogicUsage => 0;
        public decimal LogicBufferUsage => 0;
        public decimal LogicPowerDraw => 0;

        // Learning properties
        public int LearningModuleCount => LearningModules.Count();
        public decimal LearningTotal => LearningModules.Sum(s => s.DataCapacity);
        public decimal LearningDataAvg => LearningModules.Average(s => s.DataCapacity);
        public decimal LearningBusSpeedCap => LearningModules.Sum(s => s.BusSpeed);
        public decimal LearningBusSpeedAvg => LearningModules.Average(s => s.BusSpeed);
        public decimal LearningCache => LearningModules.Sum(s => s.CacheSize);
        public decimal LearningCacheAvg => LearningModules.Average(s => s.CacheSize);
        public decimal LearningPowerCap => LearningModules.Sum(s => s.PowerCap);
        public decimal LearningPowerAvg => LearningModules.Average(s => s.PowerCap);
        public decimal LearningDCap => LearningModules
            .Where(s => s.SocketType == DataSocketType.D1 ||
                s.SocketType == DataSocketType.D2)
            .Sum(s => s.DataCapacity);
        public decimal LearningNCap => LearningModules
            .Where(s => s.SocketType == DataSocketType.N1 ||
                s.SocketType == DataSocketType.N2)
            .Sum(s => s.DataCapacity);
        public decimal LearningUsage => 0;
        public decimal LearningBufferUsage => 0;
        public decimal LearningPowerDraw => 0;

        // Memory properties
        public int MemoryModuleCount => MemoryModules.Count();
        public decimal MemoryTotal => MemoryModules.Sum(s => s.DataCapacity);
        public decimal MemoryDataAvg => MemoryModules.Average(s => s.DataCapacity);
        public decimal MemoryBusSpeedCap => MemoryModules.Sum(s => s.BusSpeed);
        public decimal MemoryBusSpeedAvg => MemoryModules.Average(s => s.BusSpeed);
        public decimal MemoryCache => MemoryModules.Sum(s => s.CacheSize);
        public decimal MemoryCacheAvg => MemoryModules.Average(s => s.CacheSize);
        public decimal MemoryPowerCap => MemoryModules.Sum(s => s.PowerCap);
        public decimal MemoryPowerAvg => MemoryModules.Average(s => s.PowerCap);
        public decimal MemoryDCap => MemoryModules
            .Where(s => s.SocketType == DataSocketType.D1 ||
                s.SocketType == DataSocketType.D2)
            .Sum(s => s.DataCapacity);
        public decimal MemoryNCap => MemoryModules
            .Where(s => s.SocketType == DataSocketType.N1 ||
                s.SocketType == DataSocketType.N2)
            .Sum(s => s.DataCapacity);
        public decimal MemoryUsage => 0;
        public decimal MemoryBufferUsage => 0;
        public decimal MemoryPowerDraw => 0;

        private void OnEnable()
        {
            GetLogicModules();
            GetLearningModules();
            GetMemoryModules();
            GetHybridModules();

            foreach (CircuitPanel panel in LogicPanels)
                panel.OnModuleChange += UpdateModules;
        }
        private void OnDestroy()
        {
            foreach (CircuitPanel panel in LogicPanels)
                panel.OnModuleChange -= UpdateModules;
        }

        private void UpdateModules(CircuitType type)
        {
            if (type == CircuitType.Hybrid)
            {
                // Hybrid
                GetHybridModules();
            } else if (type == CircuitType.Logic)
            {
                // Logic
                GetLogicModules();
            } else if (type == CircuitType.Learning)
            {
                // Learning
                GetLearningModules();
            } else if (type == CircuitType.Memory)
            {
                // Memory
                GetMemoryModules();
            } else
            {
                // Not connected or not valid
            }
        }
        private void GetHybridModules()
        {
            _hybridModules = GetModulesFromPanels<IModule>(HybridPanels);
            UpdateAllProps();
        }
        private void GetLogicModules()
        {
            _logicModules = GetModulesFromPanels<ILogicModule>(LogicPanels);
            UpdateLogicProps();
        }
        private void GetLearningModules()
        {
            _learningModules = GetModulesFromPanels<IDataModule>(LearningPanels);
            UpdateLearningProps();
        }
        private void GetMemoryModules()
        {
            _memoryModules = GetModulesFromPanels<IDataModule>(MemoryPanels);
            UpdateMemoryProps();
        }
        private void UpdateAllProps()
        {
            UpdateLogicProps();
            UpdateLearningProps();
            UpdateMemoryProps();
        }
        private void UpdateLogicProps()
        {
            OnPropertyChange(nameof(LogicModuleCount), LogicModuleCount);
            OnPropertyChange(nameof(ClockSpeedTotal), ClockSpeedTotal);
            OnPropertyChange(nameof(ClockSpeedAvg), ClockSpeedAvg);
            OnPropertyChange(nameof(Threads), Threads);
            OnPropertyChange(nameof(LogicBusSpeedTotal), LogicBusSpeedTotal);
            OnPropertyChange(nameof(LogicBusSpeedAvg), LogicBusSpeedAvg);
            OnPropertyChange(nameof(LogicCacheCap), LogicCacheCap);
            OnPropertyChange(nameof(LogicCacheAvg), LogicCacheAvg);
            OnPropertyChange(nameof(LogicPowerCap), LogicPowerCap);
            OnPropertyChange(nameof(LogicPowerAvg), LogicPowerAvg);
            OnPropertyChange(nameof(LogicDCap), LogicDCap);
            OnPropertyChange(nameof(LogicQCap), LogicQCap);
    }
        private void UpdateLearningProps()
        {
            OnPropertyChange(nameof(LearningModuleCount), LearningModuleCount);
            OnPropertyChange(nameof(LearningTotal), LearningTotal);
            OnPropertyChange(nameof(LearningDataAvg), LearningDataAvg);
            OnPropertyChange(nameof(LearningBusSpeedCap), LearningBusSpeedCap);
            OnPropertyChange(nameof(LearningBusSpeedAvg), LearningBusSpeedAvg);
            OnPropertyChange(nameof(LearningCache), LearningCache);
            OnPropertyChange(nameof(LearningCacheAvg), LearningCacheAvg);
            OnPropertyChange(nameof(LearningPowerCap), LearningPowerCap);
            OnPropertyChange(nameof(LearningPowerAvg), LearningPowerAvg);
            OnPropertyChange(nameof(LearningDCap), LearningDCap);
            OnPropertyChange(nameof(LearningNCap), LearningNCap);
        }
        private void UpdateMemoryProps()
        {
            OnPropertyChange(nameof(MemoryModuleCount), MemoryModuleCount);
            OnPropertyChange(nameof(MemoryTotal), MemoryTotal);
            OnPropertyChange(nameof(MemoryDataAvg), MemoryDataAvg);
            OnPropertyChange(nameof(MemoryBusSpeedCap), MemoryBusSpeedCap);
            OnPropertyChange(nameof(MemoryBusSpeedAvg), MemoryBusSpeedAvg);
            OnPropertyChange(nameof(MemoryCache), MemoryCache);
            OnPropertyChange(nameof(MemoryCacheAvg), MemoryCacheAvg);
            OnPropertyChange(nameof(MemoryPowerCap), MemoryPowerCap);
            OnPropertyChange(nameof(MemoryPowerAvg), MemoryPowerAvg);
            OnPropertyChange(nameof(MemoryDCap), MemoryDCap);
            OnPropertyChange(nameof(MemoryNCap), MemoryNCap);
        }
        private IEnumerable<T> GetModulesFromPanels<T>(CircuitPanel[] panels) where T : IModule
        {
            return panels
                .Where(p => p.Modules is IEnumerable<T>)
                .Select(p => (IEnumerable <T>) p.Modules)
                .SelectMany(m => m);
        }
    }
}
