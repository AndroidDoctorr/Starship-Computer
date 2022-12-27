using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotConnector : MonoBehaviour
{
    public CircuitSlot Slot;

    public delegate void OnConnectDelegate(Circuit circuit, bool isConnected);
    public event OnConnectDelegate OnConnect;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        CircuitConnector cc = other.GetComponent<CircuitConnector>();
        if (cc != null)
            OnConnect(cc.Circuit, true);
    }
    private void OnTriggerExit(Collider other)
    {
        CircuitConnector cc = other.GetComponent<CircuitConnector>();
        if (cc != null)
            OnConnect(cc.Circuit, false);
    }
}
