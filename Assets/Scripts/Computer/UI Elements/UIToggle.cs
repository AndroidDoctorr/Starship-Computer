using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIToggle : UIElement
{
    private bool _isMoving = false;
    private string _sourceName;
    private bool _isOn = false;

    public bool IsActive = true;
    public bool KeepColor = false;
    public string ActionName;

    public bool StartOn = false;

    public GameObject Knob;
    public GameObject OffCover;
    public Transform OnPosition;
    public Transform OffPosition;

    public delegate void OnToggleAction(string sourceName, string actionName, GameObject hand);
    public event OnToggleAction onToggle;

    void Start()
    {
        _sourceName = transform.parent.gameObject.name;

        if (StartOn) SetToOn(true);
    }
    void Update()
    {
        if (_isMoving)
        {
            MoveTowardsPosition(Time.deltaTime * 0.1f);
            if (IsKnobClose())
                SnapToPosition();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!IsActive) return;
        if (_isMoving) return;

        if (other.name.ToLower().Contains("finger"))
            ToggleButton(other.gameObject);
    }
    private void ToggleButton(GameObject hand)
    {
        Debug.Log("Toggle activated: " + ActionName);
        onToggle(_sourceName, ActionName, hand);

        if (_isOn) SetToOff(); else SetToOn();
    }
    public override void SetColor(Color color)
    {
        if (KeepColor) return;
        var image = GetComponent<Image>();
        image.color = color;
    }
    private void SetToOn()
    {
        SetToOn(false);
    }
    private void SetToOn(bool doInstant)
    {
        _isOn = true;
        OffCover.SetActive(false);
        if (doInstant) SnapToPosition();
        else _isMoving = true;
    }
    private void SetToOff()
    {
        _isOn = false;
        OffCover.SetActive(true);
        _isMoving = true;
    }
    private void MoveTowardsPosition(float step)
    {
        Vector3 destination = (_isOn ? OnPosition : OffPosition).position;
        Vector3 knobPos = Knob.transform.position;
        Vector3.MoveTowards(knobPos, destination, step);
    }
    private bool IsKnobClose()
    {
        Vector3 pos = (_isOn ? OnPosition : OffPosition).position;
        Vector3 knobPos = Knob.transform.position;
        float dist = Vector3.Distance(pos, knobPos);
        return (dist < 0.001);
    }
    private void SnapToPosition()
    {
        Vector3 pos = (_isOn ? OnPosition : OffPosition).position;
        Knob.transform.position = pos;
        _isMoving = false;
    }
}
