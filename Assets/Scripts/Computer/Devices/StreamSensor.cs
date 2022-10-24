using Assets.Scripts.Computer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputSettings;

public class StreamSensor : Device
{
    public KineticProcess Stream;
    public delegate void VChangeDelegate(double newV);
    public event VChangeDelegate OnVChange;
    public delegate void MdotChangeDelegate(double newMdot);
    public event MdotChangeDelegate OnMdotChange;
    public delegate void SigmaChangeDelegate(double newSigma);
    public event SigmaChangeDelegate OnSigmaChange;
    void OnEnable()
    {
        Stream.OnVChange += UpdateV;
        Stream.OnMdotChange += UpdateMdot;
        Stream.OnSigmaChange += UpdateSigma;
    }
    private void OnDestroy()
    {
        Stream.OnVChange -= UpdateV;
        Stream.OnMdotChange -= UpdateMdot;
        Stream.OnSigmaChange -= UpdateSigma;
    }
    private void UpdateV(double newV)
    {
        OnVChange(newV);
    }
    private void UpdateMdot(double newMdot)
    {
        OnMdotChange(newMdot);
    }
    private void UpdateSigma(double newSigma)
    {
        OnSigmaChange(newSigma);
    }
}
