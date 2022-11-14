using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum Orientation { Horizontal, Vertical }
public class UISlider : UIElement
{
    private bool _isSliding = false;
    private bool _hasBeenPreset = false;
    private GameObject _interactor;
    private float _startWidth;
    private float _startHeight;

    public UIButton Button;
    public Image Outline;
    public TMP_Text Label;
    public Transform Bottom;
    public Transform Top;
    public RectTransform Cover;
    public float StartValue = 0;
    public float Limit = 1;
    public string LabelText = "";
    public Orientation Orientation;

    public delegate void OnSetLevel(float level);
    public event OnSetLevel OnLevelSet;
    private void OnEnable()
    {
        Button.onButtonPress += StartSlide;
        Button.onButtonExit += ExitSlide;
    }
    void Start()
    {
        if (!_hasBeenPreset) SlideTo(StartValue);
        _startWidth = Cover.rect.width;
        _startHeight = Cover.rect.height;
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
        bool isNegative = Vector3.Dot(trackVector, projection) < 0;
        return isNegative ? 0 : output > Limit ? Limit : output;
    }
    public void SlideTo(float output)
    {
        Vector3 trackVector = Top.position - Bottom.position;
        Vector3 projection = output * trackVector;
        Button.transform.position = Bottom.position + projection;

        OnLevelSet(output);

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
        if (Orientation == Orientation.Horizontal)
            SetCoverHorizontal(level);
        else
            SetCoverVertical(level);
        
    }
    private void SetCoverHorizontal(float level)
    {
        Cover.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _startHeight * (1 - level));
        Cover.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _startWidth);
        Cover.localPosition = new Vector2(level * _startHeight / 2, 0);
    }
    private void SetCoverVertical(float level)
    {
        Cover.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _startWidth * (1 - level));
        Cover.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _startHeight);
        Cover.localPosition = new Vector2(0, level * _startWidth / 2);
    }
    public override void SetColor(Color color)
    {
        Outline.color = color;
        Label.color = color;
        Button.SetColor(color);
    }
}
