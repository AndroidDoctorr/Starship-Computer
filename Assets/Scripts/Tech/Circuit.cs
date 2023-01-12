using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public enum CircuitType { None, Learning, Logic, Memory }
public class Circuit : MonoBehaviour
{
    private Hand _hand;
    private CircuitSlot _slot = null;
    private Rigidbody _rb;
    private AudioSource _as;

    public CircuitType Type;
    public bool IsBroken = false;
    public GameObject Intact;
    public GameObject Broken;
    public CircuitConnector Connector;
    void OnEnable()
    {
        _as = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody>();

        Interactable interactable = GetComponent<Interactable>();
        interactable.onAttachedToHand += PickUpCircuit;
        interactable.onDetachedFromHand += LetGoCircuit;
    }
    void Update()
    {

    }
    private void PickUpCircuit(Hand hand)
    {
        _hand = hand;
    }
    private void LetGoCircuit(Hand hand)
    {
        Debug.Log($"Let go circuit from hand: {hand.name}, slot: {_slot}");
        _hand = null;
        if (_slot == null)
        {
            _rb.useGravity = true;
            _rb.isKinematic = false;
        }
        else
        {
            transform.position = _rb.transform.position;
            transform.rotation = _rb.transform.rotation;
        }
    }
    public void SnapToSlot(CircuitSlot slot)
    {
        // Set the circuit's slot
        _slot = slot;
        // Snap to the slot position
        transform.position = slot.AttachmentPoint.position;
        // Parent the circuit to the slot (is this necessary?)
        transform.parent = slot.AttachmentPoint;
        transform.localRotation = new Quaternion();
        // Disconnect the circuit from the player hand
        DisconnectFromHand();
    }
    private void DisconnectFromHand()
    {
        // Turn off gravity
        _rb.useGravity = false;
        _rb.isKinematic = true;
        // Detach from hand if still attached
        Interactable interactable = GetComponent<Interactable>();
        if (interactable.attachedToHand && _hand != null)
        {
            _hand.DetachObject(interactable.gameObject);
            _hand = null;
        }
    }
    public void Disconnect()
    {
        _slot = null;
    }
    public void Break()
    {
        IsBroken = true;
        Intact.SetActive(false);
        Broken.SetActive(true);
        Disconnect();
    }
    public void BreakWithoutSmoke()
    {
        Break();
        ParticleSystem ps = Broken.GetComponentInChildren<ParticleSystem>();
        if (ps != null) ps.Stop();
    }
}
