using Assets.Scripts;
using Assets.Scripts.Computer;
using Assets.Scripts.Computer.Core;
using Assets.Scripts.Computer.Systems.Environment;
using Assets.Scripts.Computer.UI_Elements.ListItems;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ResourceAllocatorUI : GenericUI
{
    public ResourceAllocator ResourceAllocator;

    public UIProperty MemoryDevices;
    public UIProperty DMemoryTotal;
    public UIProperty NMemoryTotal;
    public UIProperty MemoryUsage;
    public UIProperty MemoryBufferCap;
    public UIProperty MemoryBuffer;
    public UIProperty MemoryPowerCap;
    public UIProperty MemoryPower;
    public UIProperty MemoryCache;
    public UIProperty MemoryTemp;

    public UIProperty LearningDevices;
    public UIProperty DLearningTotal;
    public UIProperty NLearningTotal;
    public UIProperty LearningUsage;
    public UIProperty LearningBufferCap;
    public UIProperty LearningBuffer;
    public UIProperty LearningPowerCap;
    public UIProperty LearningPower;
    public UIProperty LearningCache;
    public UIProperty LearningTemp;

    public UIProperty LogicDevices;
    public UIProperty DLogicTotal;
    public UIProperty QLogicTotal;
    public UIProperty LogicUsage;
    public UIProperty LogicBufferCap;
    public UIProperty LogicBuffer;
    public UIProperty LogicPowerCap;
    public UIProperty LogicPower;
    public UIProperty LogicCache;
    public UIProperty LogicTemp;

    private void OnEnable()
    {
        ResourceAllocator.OnPropertyChange += UpdateProp;
    }
    private void OnDestroy()
    {
        ResourceAllocator.OnPropertyChange -= UpdateProp;
    }

    private void UpdateProp(string name, object value)
    {
        switch (name)
        {
            // Logic properties
            case nameof(ResourceAllocator.LogicModuleCount):
                LogicDevices.ValueText.text = value.ToString();
                break;
            case nameof(ResourceAllocator.LogicDCap):
                DLogicTotal.ValueText.text = ((decimal) value).ToString("#.###");
                break;
            case nameof(ResourceAllocator.LogicQCap):
                QLogicTotal.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            case nameof(ResourceAllocator.LogicUsage):
                LogicUsage.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            case nameof(ResourceAllocator.LogicCacheCap):
                LogicCache.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            case nameof(ResourceAllocator.LogicBufferCap):
                LogicBufferCap.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            case nameof(ResourceAllocator.LogicPowerCap):
                LogicPowerCap.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            // LogicPower
            // LogicBuffer
            // LogicTemp

            // Learning properties
            case nameof(ResourceAllocator.LearningModuleCount):
                LearningDevices.ValueText.text = value.ToString();
                break;
            case nameof(ResourceAllocator.LearningDCap):
                DLearningTotal.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            case nameof(ResourceAllocator.LearningNCap):
                NLearningTotal.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            case nameof(ResourceAllocator.LearningUsage):
                LearningUsage.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            case nameof(ResourceAllocator.LearningCache):
                LearningCache.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            case nameof(ResourceAllocator.LearningBufferCap):
                LearningBufferCap.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            case nameof(ResourceAllocator.LearningPowerCap):
                LearningPowerCap.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            // LearningBuffer
            // LearningPower
            // LearningTemp

            // Memory properties


            default:
                break;
        }
    }
}
