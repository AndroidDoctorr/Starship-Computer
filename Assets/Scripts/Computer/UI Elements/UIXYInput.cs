using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIXYInput : UIElement
{
    private bool _isSliding = false;
    private bool _hasBeenPreset = false;
    private GameObject _interactor;

    public UIButton Button;
    public Image Outline;
    public TMP_Text Label;
    public Transform Bottom;
    public Transform Top;
    public RectTransform Cover;
    public float MaxValue = 10;
    public float MinValue = -10;
    public float StartValue = 0;
    public float Limit = 1;
    public string LabelText = "";

    public delegate void OnSetLevel(float level);
    public event OnSetLevel OnLevelSet;

    void Start()
    {
        Button.onButtonPress += StartSlide;
        Button.onButtonExit += ExitSlide;
        if (!_hasBeenPreset) SlideTo(StartValue);
    }
    void Update()
    {
        if (_isSliding)
        {
            Slide();
        }
    }
    void Slide()
    {
        // Get vector from bottom of slider to hand
        Vector3 pointer = _interactor.transform.position - Bottom.transform.position;
        // Get vector along slider
        Vector3 trackVector = Top.position - Bottom.position;
        // Get projection of hand along slider
        Vector3 projection = Vector3.Project(pointer, trackVector);
        // Determine output value
        float output = projection.magnitude / trackVector.magnitude;
        // Determine if negative (since magnitudes are irrespective of direction)
        if (Vector3.Dot(trackVector, projection) < 0) output = 0;
        OnLevelSet(output);
        SlideTo(output);
    }
    public void SlideTo(float output)
    {
        // Limit between 0 and Limit
        if (output >= Limit)
            output = Limit;
        else if (output <= 0)
            output = 0;

        Vector3 trackVector = Top.position - Bottom.position;
        Vector3 projection = trackVector * output;
        Button.transform.position = Bottom.position + projection;

        SetCover(output);

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
    void SetCover(float level)
    {
        Cover.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 21 * (1 - level));
        Cover.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 3);
        Cover.localPosition = new Vector2(0, level * 10.5f);
    }
    public override void SetColor(Color color)
    {
        Outline.color = color;
        Label.color = color;
        Button.SetColor(color);
    }
}
