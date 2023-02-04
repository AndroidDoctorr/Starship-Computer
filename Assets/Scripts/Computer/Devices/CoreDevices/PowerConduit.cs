using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PowerConduit : MonoBehaviour
{
    private Hand _hand;
    private ConduitSlot _slot;
    private Rigidbody _rb;
    private AudioSource _as;

    public bool IsBroken = false;
    public GameObject Intact;
    public GameObject Broken;
    public ConduitTerminal PositiveTerminal;
    public ConduitTerminal NegativeTerminal;
    public AudioClip[] SoundEffects;
    public ParticleSystem ParticleStream;
    void OnEnable()
    {
        _as = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody>();

        Interactable interactable = GetComponent<Interactable>();

        interactable.onAttachedToHand += PickUpConduit;
        interactable.onDetachedFromHand += LetGoConduit;
    }

    private void PickUpConduit(Hand hand)
    {
        _hand = hand;
    }
    private void LetGoConduit(Hand hand)
    {
        _hand = null;
        if (_slot == null)
        {
            _rb.useGravity = true;
            _rb.isKinematic = false;
        }
        else
        {
            transform.position = _rb.transform.position;
            transform.rotation = new Quaternion();
        }
    }
    public void SnapToSlot(ConduitSlot slot)
    {
        // Set the conduit's slot
        _slot = slot;
        // Snap to the slot position
        transform.position = slot.transform.position;
        // Parent the conduit to the slot (is this necessary?)
        transform.parent = slot.transform;
        transform.localRotation = new Quaternion();
        // Play sound effect
        _as.clip = SoundEffects[0];
        _as.PlayDelayed(0);
        // Start particle stream
        ParticleStream.Play();
        // Disconnect the conduit from the player hand
        DisconnectFromHand();
    }
    private void DisconnectFromHand()
    {
        // Turn off gravity
        _rb.useGravity = false;
        _rb.isKinematic = true;
        // Detach from hand if still attached
        Interactable interactable = GetComponent<Interactable>();
        if (_hand != null && interactable.attachedToHand)
        {
            _hand.DetachObject(interactable.gameObject);
            _hand = null;
        }
    }
    public void Disconnect()
    {
        // Play sound effect
        _as.clip = SoundEffects[1];
        _as.PlayDelayed(0);
        // Remove slot
        _slot = null;
        // Stop particle stream
        ParticleStream.Stop();
    }
    public void Break()
    {
        IsBroken = true;
        Intact.SetActive(false);
        Broken.SetActive(true);
        Disconnect();
    }
}
