using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScrollView : MonoBehaviour
{
    private int _scrollDirection = 0;

    public GameObject ListItemModel;
    public UIButton ScrollUp;
    public UIButton ScrollDown;
    public Transform ScrollOffset;
    public float ScrollSpeed = 1;
    public float MinScroll = 0;
    public float MaxScroll = 1.25f;

    private void OnEnable()
    {
        ScrollUp.onButtonPress += StartScrollUp;
        ScrollUp.onButtonExit += EndScrollUp;
        ScrollDown.onButtonPress += StartScrollDown;
        ScrollDown.onButtonExit += EndScrollDown;
    }
    private void OnDestroy()
    {
        ScrollUp.onButtonPress -= StartScrollUp;
        ScrollUp.onButtonExit -= EndScrollUp;
        ScrollDown.onButtonPress -= StartScrollDown;
        ScrollDown.onButtonExit -= EndScrollDown;
    }
    private void Start()
    {
        PopulateList();
    }
    private void Update()
    {
        if (_scrollDirection != 0)
            Scroll(_scrollDirection * ScrollSpeed * Time.deltaTime);
    }



    private void PopulateList()
    {
        // Loop through data items
        //   Instantiate ListItemModel prefab
        //   Populate with item details
    }
    private void Scroll(float amount)
    {
        Vector3 pos = ScrollOffset.localPosition;
        float y = pos.y + amount;

        if (y < MinScroll) y = MinScroll;
        if (y > MaxScroll) y = MaxScroll;

        pos.y = y;
        ScrollOffset.localPosition = pos;
    }
    private void StartScrollUp(string actionName, GameObject hand)
    {
        _scrollDirection = -1;
    }
    private void StartScrollDown(string actionName, GameObject hand)
    {
        _scrollDirection = 1;
    }
    private void EndScrollUp(string actionName, GameObject hand)
    {
        _scrollDirection = 0;
    }
    private void EndScrollDown(string actionName, GameObject hand)
    {
        _scrollDirection = 0;
    }
}
