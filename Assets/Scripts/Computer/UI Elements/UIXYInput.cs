using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIXYInput : UIElement
{
    private enum Axis { x, y };

    private bool _isSliding = false;
    private bool _hasBeenPreset = false;
    private GameObject _interactor;

    public UIButton Knob;
    public Image Outline;
    public TMP_Text Label;
    public Transform Bottom;
    public Transform Top;
    public Transform Left;
    public Transform Right;

    public RectTransform Cover;
    public float StartX = 0;
    public float StartY = 0;
    public float LimitX = 1;
    public float LimitY = 1;
    public string LabelText = "";

    public delegate void OnSetLevel(float x, float y);
    public event OnSetLevel OnLevelSet;

    private void OnEnable()
    {
        Knob.onButtonPress += StartSlide;
        Knob.onButtonExit += ExitSlide;
    }
    void Start()
    {
        if (!_hasBeenPreset) SlideTo(StartX, StartY);
    }
    void Update()
    {
        if (_isSliding)
        {
            float x = GetOutputAlongAxis(Axis.x);
            float y = GetOutputAlongAxis(Axis.y);
            OnLevelSet(x, y);
            SlideTo(x, y);
        }
    }
    private float GetOutputAlongAxis(Axis axis)
    {
        Vector3 start = axis == Axis.x ? Left.position : Bottom.position;
        Vector3 end = axis == Axis.x ? Right.position : Top.position;

        Vector3 pointer = _interactor.transform.position - start;
        Vector3 trackVector = end - start;
        Vector3 projection = Vector3.Project(pointer, trackVector);

        float output = projection.magnitude / trackVector.magnitude;
        // Limit to range
        float limit = axis == Axis.x ? LimitX : LimitY;
        return output < 0 ? 0 : output > limit ? limit : output;
    }
    public void SlideTo(float x, float y)
    {
        Vector3 xAxis = Right.position - Left.position;
        Vector3 yAxis = Top.position - Bottom.position;
        Vector3 xProjection = xAxis * x + Right.position;
        Vector3 yProjection = yAxis * y + Bottom.position;
        Knob.transform.position = xProjection + yProjection;

        _hasBeenPreset = true;
    }
    void StartSlide(string source, string name, GameObject interactor)
    {
        _isSliding = true;
        _interactor = interactor;
    }
    void ExitSlide(string source, string name, GameObject interactor)
    {
        _isSliding = false;
    }
    public override void SetColor(Color color)
    {
        Outline.color = color;
        Label.color = color;
        Knob.SetColor(color);
    }
}
