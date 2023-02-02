using Assets.Scripts;
using Assets.Scripts.Computer;
using Assets.Scripts.Computer.Systems.Environment;
using Assets.Scripts.Computer.UI_Elements.ListItems;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ResourceAllocatorUI : GenericUI
{
    // public ResourceAllocator ResourceAllocator;
    public UIProperty DMemoryTotal;
    public UIProperty NMemoryTotal;
    public UIProperty MemoryDevices;
    public UIProperty MemoryUsage;
    public UIProperty MemoryBufferCap;
    public UIProperty MemoryBuffer;
    public UIProperty MemoryPowerCap;
    public UIProperty MemoryPower;
    public UIProperty MemoryCache;
    public UIProperty MemoryTemp;

    public UIProperty DLearningTotal;
    public UIProperty NLearningTotal;
    public UIProperty LearningDevices;
    public UIProperty LearningUsage;
    public UIProperty LearningBufferCap;
    public UIProperty LearningBuffer;
    public UIProperty LearningPowerCap;
    public UIProperty LearningPower;
    public UIProperty LearningCache;
    public UIProperty LearningTemp;

    public UIProperty DLogicTotal;
    public UIProperty QLogicTotal;
    public UIProperty LogicDevices;
    public UIProperty LogicUsage;
    public UIProperty LogicBufferCap;
    public UIProperty LogicBuffer;
    public UIProperty LogicPowerCap;
    public UIProperty LogicPower;
    public UIProperty LogicCache;
    public UIProperty LogicTemp;
    void Start()
    {
        // Device[] devices = Environment.GetDevices();

    }
}
