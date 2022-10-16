using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.Computer.Core
{
    public class UsageProfile
    {
        public Guid Id { get; }
        public string Name { get; }
        public int Priority { get; private set; }
        public bool IsEnabled { get; private set; } = false;
        public double MemoryUsage { get; set; }
        public double MemoryMax { get; set; }
        public double MemoryMin { get; set; }
        public double LearningUsage { get; set; }
        public double LearningMax { get; set; }
        public double LearningMin { get; set; }
        public double ProcessingUsage { get; set; }
        public double ProcessingMax { get; set; }
        public double ProcessingMin { get; set; }

        public UsageProfile(
            int priority,
            Guid id,
            string name,
            double learningMin,
            double learningMax,
            double memoryMin,
            double memoryMax,
            double processingMin,
            double processingMax
        )
        {
            Id = id;
            Name = name;
            Priority = priority;
            LearningMin = learningMin;
            LearningMax = learningMax;
            LearningUsage = learningMin;
            MemoryMin = memoryMin;
            MemoryMax = memoryMax;
            MemoryUsage = memoryMin;
            ProcessingMin = processingMin;
            ProcessingMax = processingMax;
            ProcessingUsage = processingMin;
        }

        public bool Disable(int priority)
        {
            Debug.Log($"Disable Usage Profile: {Id}");
            if (priority > Priority)
            {
                Debug.LogWarning($"Cannot Disable Usage Profile: {Id} - Access Denied");
                return false;
            }
            IsEnabled = false;
            return true;
        }
        public bool Enable(int priority)
        {
            Debug.Log($"Enable Usage Profile: {Id}");
            if (priority > Priority)
            {
                Debug.LogWarning($"Cannot Enable Usage Profile: {Id} - Access Denied");
                return false;
            }
            
            IsEnabled = true;

            LearningUsage = LearningMin;
            MemoryUsage = MemoryMin;
            ProcessingUsage = ProcessingMin;

            return true;
        }
        public bool SetPriority(int priority, int newPriority)
        {
            Debug.Log($"Set Usage Profile Priority: {Id}");
            if (priority > 1)
            {
                Debug.LogWarning($"Cannot Set Usage Profile Priority: {Id} - Access Denied");
                return false;
            }   
            Priority = newPriority;
            return true;
        }
        public bool SetLearningUsage(int priority, double level)
        {
            Debug.Log($"Set Usage Profile Learning: {Id}");
            if (priority > Priority)
            {
                Debug.LogWarning($"Cannot Set Usage Profile Learning: {Id} - Access denied");
                return false;
            }
            if (level < LearningMin)
            {
                Debug.LogWarning($"Cannot Set Learning usage below {LearningMin}");
                return false;
            }
            if (level > LearningMax)
            {
                Debug.LogWarning($"Cannot Set Learning usage above {LearningMax}");
                return false;
            }

            LearningUsage = level;
            return true;
        }
        public bool SetMemoryUsage(int priority, double level)
        {
            Debug.Log($"Set Usage Profile Memory: {Id}");
            if (priority > Priority)
            {
                Debug.LogWarning($"Cannot Set Usage Profile Memory: {Id} - Access denied");
                return false;
            }
            if (level < MemoryMin)
            {
                Debug.LogWarning($"Cannot Set Memory usage below {MemoryMin}");
                return false;
            }
            if (level > MemoryMax)
            {
                Debug.LogWarning($"Cannot Set Memory usage above {MemoryMax}");
                return false;
            }
            MemoryUsage = level;
            return true;
        }
        public bool SetProcessingUsage(int priority, double level)
        {
            Debug.Log($"Set Usage Profile Processing: {Id}");
            if (priority > Priority)
            {
                Debug.LogWarning($"Cannot Set Usage Profile Processing: {Id} - Access denied");
                return false;
            }
            if (level < ProcessingMin)
            {
                Debug.LogWarning($"Cannot Set Processing usage below {ProcessingMin}");
                return false;
            }
            if (level > ProcessingMax)
            {
                Debug.LogWarning($"Cannot Set Processing usage above {ProcessingMax}");
                return false;
            }
            ProcessingUsage = level;
            return true;
        }
    }
}
