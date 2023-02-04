using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConduitSlot : MonoBehaviour
{
    private bool _initialCheck = false;
    private bool _oneConnected = false;
    private PowerConduit _connectedConduit;

    public delegate void OnConnectDelegate(bool isConnected, int slotId, PowerConduit conduit);
    public event OnConnectDelegate OnConnect;

    public bool IsOccupied { get; private set; }
    public int SlotId;

    public ConduitConnector Connector1;
    public ConduitConnector Connector2;
    public GameObject Valid;
    public GameObject Invalid;
    void OnEnable()
    {
        Connector1.OnConnect += ConnectConduit;
        Connector2.OnConnect += ConnectConduit;
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
        PowerConduit conduit = GetComponentInChildren<PowerConduit>();
        if (conduit == null) SetValidConduit(false, conduit);
        else if (conduit.IsBroken) SetValidConduit(false, conduit);
        else
        {
            conduit.SnapToSlot(this);
            SetValidConduit(true, conduit);
        }
    }
    
    private void ConnectConduit(PowerConduit conduit, bool isConnected)
    {
        if (conduit.IsBroken) SetValidConduit(false, conduit);
        if (isConnected)
        {
            if (IsOccupied) return;
            if (_oneConnected)
                SetConnectedConduit(conduit);
            else
                _oneConnected = true;
        }
        else if (_connectedConduit != null)
            DisconnectConduit();
        else if (_oneConnected)
            _oneConnected = false;
    }
    public void SetConnectedConduit(PowerConduit conduit)
    {
        _connectedConduit = conduit;
        IsOccupied = true;

        SetValidConduit(!conduit.IsBroken, conduit);

        conduit.SnapToSlot(this);
    }
    private void DisconnectConduit()
    {
        _oneConnected = false;
        _connectedConduit.Disconnect();
        _connectedConduit = null;
        IsOccupied = false;
        SetValidConduit(false, null);
    }
    private void SetValidConduit(bool isValid, PowerConduit conduit)
    {
        Invalid.SetActive(!isValid);
        Valid.SetActive(isValid);
        OnConnect(isValid, SlotId, conduit);
    }
}
