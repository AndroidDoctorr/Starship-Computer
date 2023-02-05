﻿using Assets.Scripts.Computer.Core.CoreModules;
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
    public class ResourceAllocator : CoreSystem
    {
        // Module Panels
        public CircuitPanel[] LogicPanels;
        public CircuitPanel[] LearningPanels;
        public CircuitPanel[] MemoryPanels;
        public CircuitPanel[] HybridPanels;

        // Called whenever modules are added or removed
        public delegate void ModuleChangeDelegate(Circuit circuit);
        public event ModuleChangeDelegate OnModuleChange;

        public IEnumerable<ILogicModule> LogicModules
        {
            get
            {
                IEnumerable<ILogicModule> dedicatedModules =
                    GetModulesFromPanels<ILogicModule>(LogicPanels);
                IEnumerable<ILogicModule> hybridModules =
                    GetModulesFromPanels<ILogicModule>(HybridPanels);
                return dedicatedModules.Concat(hybridModules);
            }
        }
        public IEnumerable<IDataModule> LearningModules
        {
            get
            {
                IEnumerable<IDataModule> dedicatedModules =
                    GetModulesFromPanels<IDataModule>(LearningPanels);
                IEnumerable<IDataModule> hybridModules =
                    GetModulesFromPanels<IDataModule>(HybridPanels);
                return dedicatedModules.Concat(hybridModules);
            }
        }
        public IEnumerable<IDataModule> MemoryModules
        {
            get
            {
                IEnumerable<IDataModule> dedicatedModules =
                    GetModulesFromPanels<IDataModule>(MemoryPanels);
                IEnumerable<IDataModule> hybridModules =
                    GetModulesFromPanels<IDataModule>(HybridPanels);
                return dedicatedModules.Concat(hybridModules);
            }
        }

        // Logic properties
        public int LogicModuleCount => LogicModules.Count();
        public decimal ClockSpeedTotal => LogicModules.Sum(s => s.ClockSpeed);
        public decimal ClockSpeedAcg => LogicModules.Average(s => s.ClockSpeed);
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
        public decimal LearningIOCap => LearningModules.Sum(s => s.BusSpeed);
        public decimal LearningIOAvg => LearningModules.Average(s => s.BusSpeed);
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
        public decimal MemoryBusCap => MemoryModules.Sum(s => s.BusSpeed);
        public decimal MemoryBusAvg => MemoryModules.Average(s => s.BusSpeed);
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
