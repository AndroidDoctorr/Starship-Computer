using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class UITouchpad : UIElement
{
    // This is a bare-bones touchpad, like XY input but more generic. Returns the same output
    private enum Axis { x, y };

    private bool _isTouching = false;
    private GameObject _interactor;

    public bool IsActive = true;
    public string ActionName;
    public Transform Top;
    public Transform Right;
    public Transform Origin;

    public delegate void TouchDelegate(string actionName, GameObject interactor, float x, float y);
    public event TouchDelegate OnTouch;

    void Start()
    {
        
    }
    void Update()
    {
        if (_isTouching)
        {
            float x = GetOutputAlongAxis(Axis.x);
            float y = GetOutputAlongAxis(Axis.y);
            OnTouch(ActionName, _interactor, x, y);
        }
    }
    private float GetOutputAlongAxis(Axis axis)
    {
        Vector3 start = Origin.position;
        Vector3 end = axis == Axis.x ? Right.position : Top.position;

        Vector3 pointer = _interactor.transform.position - start;
        Vector3 trackVector = end - start;
        Vector3 projection = Vector3.Project(pointer, trackVector);

        float output = projection.magnitude / trackVector.magnitude;
        // Limit to range
        bool isNegative = Vector3.Dot(trackVector, projection) < 0;
        return isNegative ? 0 : output > 1 ? 1 : output;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!IsActive) return;
        if (other.name.ToLower().Contains("finger"))
        {
            _interactor = other.gameObject;
            _isTouching = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!IsActive) return;
        if (other.gameObject == _interactor)
            _isTouching = false;
    }
}
