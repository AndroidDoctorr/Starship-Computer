using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIXYInput : UIElement
{
    // A wrapper for UITouchpad - Adds a knob, an outline and a label
    // Also scales output to some defined maxima (LimitX and LimitY)
    private bool _hasBeenPreset = false;
    private GameObject _interactor;

    public Transform Knob;
    public UITouchpad Touchpad;
    public Image KnobOutline;
    public Image KnobCenter;
    public Image Outline;
    public TMP_Text Label;
    public string ActionName;

    public float StartX = 0;
    public float StartY = 0;
    public float LimitX = 1;
    public float LimitY = 1;
    public string LabelText = "";

    public delegate void OnSetLevel(string actionName, GameObject interactor, float x, float y);
    public event OnSetLevel OnLevelSet;

    private void OnEnable()
    {
        Touchpad.ActionName = ActionName;
        Touchpad.OnTouch += Slide;
    }
    private void OnDestroy()
    {
        Touchpad.OnTouch -= Slide;
    }
    void Start()
    {
        if (!_hasBeenPreset) PresetTo(StartX, StartY);
    }
    void Update()
    {

    }
    public void PresetTo(float x, float y)
    {
        _hasBeenPreset = true;
        SlideTo(x, y);
    }
    public void SlideTo(float x, float y)
    {
        Vector3 xAxis = Touchpad.Right.localPosition - Touchpad.Origin.localPosition;
        Vector3 yAxis = Touchpad.Top.localPosition - Touchpad.Origin.localPosition;
        Vector3 xProjection = x * xAxis;
        Vector3 yProjection = y * yAxis;
        xProjection.y = 0;
        yProjection.x = 0;
        Knob.transform.localPosition = Touchpad.Origin.localPosition + xProjection + yProjection;        
    }
    void Slide(string actionName, GameObject interactor, float x, float y)
    {
        _interactor = interactor;
        SlideTo(x, y);
        OnLevelSet(actionName, interactor, x * LimitX, y * LimitY);
    }
    public void SetKnobColor(Color color)
    {
        KnobCenter.color = color;
    }
    public override void SetColor(Color color)
    {
        Outline.color = color;
        Label.color = color;
        KnobOutline.color = color;
    }
}
