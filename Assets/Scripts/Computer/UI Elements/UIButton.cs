using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : UIElement
{
    private bool _glowing = false;

    public bool IsActive = true;
    public bool KeepColor = false;
    public string ActionName;

    public delegate void OnButtonAction(string actionName, GameObject hand);
    public event OnButtonAction onButtonPress;
    public event OnButtonAction onButtonExit;

    void Start()
    {

    }
    void Update()
    {
        // TODO: make this happen more slowly
        /*
        if (_glowing)
        {
            var image = GetComponent<Image>();
            image.color = DefaultColor;
            _glowing = false;
        }
        */
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!IsActive) return;
        if (other.name.ToLower().Contains("finger"))
            ActivateButton(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        if (!IsActive) return;
        if (other.name.ToLower().Contains("finger") && onButtonExit != null)
            onButtonExit(ActionName, other.gameObject);
    }
    private void ActivateButton(GameObject hand)
    {
        // Debug.Log("Button activated: " + ActionName);
        onButtonPress(ActionName, hand);
        // var image = GetComponent<Image>();
        // image.color = Color.white;
        _glowing = true;
    }
    public override void SetColor(Color color)
    {
        if (KeepColor) return;
        var image = GetComponent<Image>();
        image.color = color;
    }
}
