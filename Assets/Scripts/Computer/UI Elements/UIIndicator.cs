using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class UIIndicator : UIElement
{
    public Image Outline;
    public TMP_Text Label;
    public Transform Bottom;
    public Transform Top;
    public RectTransform Cover;
    public float Limit = 1;
    void Start()
    {
        // TODO: Subscribe to a property event, update every frame!!!
    }
    public void SlideTo(float output)
    {
        Debug.Log($"{gameObject.name} - Slide to {output}");
        // Limit between 0 and Limit
        if (output >= Limit)
            output = Limit;
        else if (output <= 0)
            output = 0;

        SetCover(output);
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
    }
}
