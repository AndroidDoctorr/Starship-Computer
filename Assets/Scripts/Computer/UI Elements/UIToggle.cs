using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIToggle : UIElement
{
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

    public delegate void OnToggleAction();
    public event OnToggleAction onToggle;

    void Start()
    {
        _sourceName = transform.parent.gameObject.name;

        if (StartOn) SetToOn();
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!IsActive) return;
        if (other.name.ToLower().Contains("finger"))
            ToggleButton(other.gameObject);
    }
    private void ToggleButton(GameObject hand)
    {
        Debug.Log("Button activated: " + ActionName);
        onToggle();
        _isOn = !_isOn;

        if (_isOn) SetToOn(); else SetToOff();
    }
    public override void SetColor(Color color)
    {
        if (KeepColor) return;
        var image = GetComponent<Image>();
        image.color = color;
    }
    private void SetToOn()
    {
        OffCover.SetActive(false);
        // TODO: MOVE SLOWLY AND TIME OUT, DON'T JUST TELEPORT
        Knob.transform.position = OnPosition.position;
    }
    private void SetToOff()
    {
        OffCover.SetActive(true);
        // TODO: MOVE SLOWLY AND TIME OUT, DON'T JUST TELEPORT
        Knob.transform.position = OffPosition.position;
    }
}
