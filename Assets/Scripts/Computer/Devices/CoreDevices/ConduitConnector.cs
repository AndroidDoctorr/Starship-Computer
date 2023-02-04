using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConduitConnector : MonoBehaviour
{
    public ConduitSlot Slot;

    public delegate void OnConnectDelegate(PowerConduit conduit, bool isConnected);
    public event OnConnectDelegate OnConnect;

    private void OnTriggerEnter(Collider other)
    {
        ConduitTerminal ct = other.GetComponent<ConduitTerminal>();
        if (ct != null)
            OnConnect(ct.Conduit, true);
    }
    private void OnTriggerExit(Collider other)
    {
        ConduitTerminal ct = other.GetComponent<ConduitTerminal>();
        if (ct != null)
            OnConnect(ct.Conduit, false);
    }
}
