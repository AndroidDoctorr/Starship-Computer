using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlider : UIElement
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
            float v = GetOutputAlongAxis();
            SlideTo(v);
        }
    }
    private float GetOutputAlongAxis()
    {
        Vector3 start = Bottom.position;
        Vector3 end = Top.position;

        Vector3 pointer = _interactor.transform.position - start;
        Vector3 trackVector = end - start;
        Vector3 projection = Vector3.Project(pointer, trackVector);

        float output = projection.magnitude / trackVector.magnitude;
        // Limit to range
        return output < 0 ? 0 : output > Limit ? Limit : output;
    }
    public void SlideTo(float output)
    {        
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
        Cover.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 21 * (1-level));
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
