using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerSystem : MonoBehaviour
{
    private bool _isLogicValid;
    private bool _isMemoryValid;
    private bool _isLearningValid;

    public string SystemName;

    public CircuitSlot LogicSlot;
    public CircuitSlot LearningSlot;
    public CircuitSlot MemorySlot;
    public GameObject ActiveIndicator;
    public GameObject InactiveIndicator;

    public bool IsActive { get; private set; } = true;
    void OnEnable()
    {
        LogicSlot.OnConnect += Connect;
        LearningSlot.OnConnect += Connect;
        MemorySlot.OnConnect += Connect;
    }

    void Update()
    {

    }
    private void IndicateConnection(bool isConnected)
    {
        ActiveIndicator.SetActive(isConnected);
        InactiveIndicator.SetActive(!isConnected);
    }
    private void Connect(bool isConnected, CircuitType slotType, Circuit circuit)
    {
        if (slotType == CircuitType.Logic)
            _isLogicValid = isConnected;
        if (slotType == CircuitType.Learning)
            _isLearningValid = isConnected;
        if (slotType == CircuitType.Memory)
            _isMemoryValid = isConnected;

        if (_isLogicValid && _isMemoryValid && _isLearningValid)
        {
            IsActive = true;
        }
        else if (IsActive)
        {
            IsActive = false;
        }

        IndicateConnection(IsActive);
        // SaveConfiguration(slotType, circuit);
    }

    public void SetCircuit(CircuitType slot, Circuit circuit)
    {
        Debug.Log($"Set Circuit - {slot}, {circuit.Type}");
        if (circuit == null) return;
        if (slot == CircuitType.Logic)
            LogicSlot.SetConnectedCircuit(circuit);
        else if (slot == CircuitType.Learning)
            LearningSlot.SetConnectedCircuit(circuit);
        else if (slot == CircuitType.Memory)
            MemorySlot.SetConnectedCircuit(circuit);
    }
}

