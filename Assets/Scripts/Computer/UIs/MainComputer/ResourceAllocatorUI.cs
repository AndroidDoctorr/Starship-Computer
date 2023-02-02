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
    public UIProperty DLearningTotal;
    public UIProperty NLearningTotal;
    public UIProperty LearningDevices;
    public UIProperty LearningUsage;
    public UIProperty DLogicTotal;
    public UIProperty QLogicTotal;
    public UIProperty LogicDevices;
    public UIProperty LogicUsage;
    void Start()
    {
        // Device[] devices = Environment.GetDevices();

    }
}
