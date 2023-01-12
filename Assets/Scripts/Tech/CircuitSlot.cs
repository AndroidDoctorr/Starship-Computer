using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitSlot : MonoBehaviour
{
    private bool _initialCheck = false;
    private bool _oneConnected = false;
    private Circuit _connectedCircuit;

    public delegate void OnConnectDelegate(bool isConnected, CircuitType circuitType, Circuit circuit);
    public event OnConnectDelegate OnConnect;

    public bool IsOccupied { get; private set; }
    public bool HasValidCircuit { get; private set; }
    public CircuitType Type;
    public SlotConnector Connector1;
    public SlotConnector Connector2;
    public GameObject Valid;
    public GameObject Invalid;
    public Renderer Indicator;
    public Transform AttachmentPoint;

    void OnEnable()
    {
        Connector1.OnConnect += ConnectCircuit;
        Connector2.OnConnect += ConnectCircuit;
    }
    private void OnDestroy()
    {
        Connector1.OnConnect -= ConnectCircuit;
        Connector2.OnConnect -= ConnectCircuit;
    }
    private void Start()
    {
        SetIndicatorColor();
    }
    void Update()
    {
        if (!_initialCheck)
        {
            _initialCheck = true;
            CheckIfValid();
        }
    }
    private void CheckIfValid()
    {
        Circuit circuit = GetComponentInChildren<Circuit>();
        if (circuit == null) SetValidCircuit(false);
        else SetValidCircuit(circuit.Type == Type && !circuit.IsBroken);
    }
    private void ConnectCircuit(Circuit circuit, bool isConnected)
    {
        if (isConnected)
        {
            if (IsOccupied) return;
            if (_oneConnected)
                SetConnectedCircuit(circuit);
            else
                _oneConnected = true;
        }
        else if (_connectedCircuit != null)
            DisconnectCircuit();
        else if (_oneConnected)
            _oneConnected = false;
    }
    public void SetConnectedCircuit(Circuit circuit)
    {
        Debug.Log($"Set connected circuit in slot: {circuit.Type}, {(circuit.IsBroken ? "Broken" : "Ok")}");
        _connectedCircuit = circuit;
        _oneConnected = true;
        IsOccupied = true;
        bool isValid = (circuit.Type == Type) && (!circuit.IsBroken);

        SetValidCircuit(isValid);

        circuit.SnapToSlot(this);
    }
    private void DisconnectCircuit()
    {
        Debug.Log("Disconnect Circuit");
        _oneConnected = false;
        _connectedCircuit.Disconnect();
        _connectedCircuit = null;
        IsOccupied = false;
        SetValidCircuit(false);
    }
    private void SetValidCircuit(bool isValid)
    {
        HasValidCircuit = isValid;
        Invalid.SetActive(!isValid);
        Valid.SetActive(isValid);
        // OnConnect(isValid, Type, _connectedCircuit);
    }
    private void SetIndicatorColor()
    {
        Material mat = Indicator.material;
        mat.color = Type switch {
            CircuitType.Logic => new Color(1, 0.5f, 0),
            CircuitType.Memory => new Color(0, 1, 1),
            CircuitType.Learning => new Color(0.5f, 0, 1),
            _ => Color.cyan,
        };

        Indicator.material = mat;
    }
}
