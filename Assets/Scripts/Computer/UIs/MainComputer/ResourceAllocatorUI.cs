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

public enum ResourcePropertyGroup { None, Logic, Learning, Memory, LogicUsage, LearningUsage, MemoryUsage }
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

    public override SystemBase System { get { return ResourceAllocator; } }

    protected override void OnEnable()
    {
        ResourceAllocator.OnPropertyChange += UpdateProp;

        base.OnEnable();
    }
    protected override void OnDestroy()
    {
        ResourceAllocator.OnPropertyChange -= UpdateProp;

        base.OnDestroy();
    }

    private void UpdateProp(string name, object value, params object[] parameters)
    {
        ResourcePropertyGroup group = parameters[0] != null &&
            parameters[0] is ResourcePropertyGroup ?
            (ResourcePropertyGroup) parameters[0] : default;

        switch (group)
        {
            case ResourcePropertyGroup.Logic:
                UpdateLogicProps(name, value);
                break;
            case ResourcePropertyGroup.Learning:
                UpdateLearningProps(name, value);
                break;
            case ResourcePropertyGroup.Memory:
                UpdateMemoryProps(name, value);
                break;
            case ResourcePropertyGroup.LogicUsage:
                UpdateLogicUsageProps(name, value);
                break;
            case ResourcePropertyGroup.LearningUsage:
                UpdateLearningUsageProps(name, value);
                break;
            case ResourcePropertyGroup.MemoryUsage:
                UpdateMemoryUsageProps(name, value);
                break;
            default:
                break;
        }
        
    }
    private void UpdateLogicProps(string name, object value)
    {
        switch (name)
        {
            // Logic properties
            case nameof(ResourceAllocator.LogicModuleCount):
                LogicDevices.ValueText.text = value.ToString();
                break;
            case nameof(ResourceAllocator.LogicDCap):
                DLogicTotal.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            case nameof(ResourceAllocator.LogicQCap):
                QLogicTotal.ValueText.text = ((decimal)value).ToString("#.###");
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
            default:
                break;
        }
    }
    private void UpdateLearningProps(string name, object value)
    {
        switch (name)
        {
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
            case nameof(ResourceAllocator.LearningCache):
                LearningCache.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            case nameof(ResourceAllocator.LearningBufferCap):
                LearningBufferCap.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            case nameof(ResourceAllocator.LearningPowerCap):
                LearningPowerCap.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            default:
                break;
        }
    }
    private void UpdateMemoryProps(string name, object value)
    {
        switch (name)
        {
            // Memory properties
            case nameof(ResourceAllocator.MemoryModuleCount):
                MemoryDevices.ValueText.text = value.ToString();
                break;
            case nameof(ResourceAllocator.MemoryDCap):
                DMemoryTotal.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            case nameof(ResourceAllocator.MemoryNCap):
                NMemoryTotal.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            case nameof(ResourceAllocator.MemoryCache):
                MemoryCache.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            case nameof(ResourceAllocator.MemoryBufferCap):
                MemoryBufferCap.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            case nameof(ResourceAllocator.MemoryPowerCap):
                MemoryPowerCap.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            default:
                break;
        }
    }
    private void UpdateLogicUsageProps(string name, object value)
    {
        switch (name)
        {
            case nameof(ResourceAllocator.LogicUsage):
                LogicCache.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            case nameof(ResourceAllocator.LogicBufferUsage):
                LogicBuffer.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            case nameof(ResourceAllocator.LogicPowerDraw):
                LogicPower.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            // Logic Temp
            default:
                break;
        }
    }
    private void UpdateLearningUsageProps(string name, object value)
    {
        switch (name)
        {
            case nameof(ResourceAllocator.LearningUsage):
                LearningUsage.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            case nameof(ResourceAllocator.LearningBufferUsage):
                LearningBuffer.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            case nameof(ResourceAllocator.LearningPowerDraw):
                LearningPower.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            // Learning Temp
            default:
                break;
        }
    }
    private void UpdateMemoryUsageProps(string name, object value)
    {
        switch (name)
        {
            case nameof(ResourceAllocator.MemoryUsage):
                MemoryUsage.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            case nameof(ResourceAllocator.MemoryBufferUsage):
                MemoryBuffer.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            case nameof(ResourceAllocator.MemoryPowerDraw):
                MemoryPower.ValueText.text = ((decimal)value).ToString("#.###");
                break;
            // Memory Temp
            default:
                break;
        }
    }
}
