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

    public delegate void OnButtonAction(string sourceName, string actionName, GameObject hand);
    public event OnButtonAction onToggle;

    void Start()
    {
        _sourceName = transform.parent.gameObject.name;
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
        onToggle(_sourceName, ActionName, hand);
        _isOn = !_isOn;
    }
    public override void SetColor(Color color)
    {
        if (KeepColor) return;
        var image = GetComponent<Image>();
        image.color = color;
    }
}
