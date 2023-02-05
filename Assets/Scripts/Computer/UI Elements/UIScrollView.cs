using Assets.Scripts;
using Assets.Scripts.Computer.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UI;

public class UIScrollView : UIElement
{
    private int _scrollDirection = 0;
    private List<UIListItem> _listItems = new List<UIListItem>();

    public UIListItem ListItemModel;
    public Image Border;
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
    private void Update()
    {
        if (_scrollDirection != 0)
            Scroll(_scrollDirection * ScrollSpeed * Time.deltaTime);
    }


    public void PopulateDataList(ListItemData[] data)
    {
        float offset = -0.125f;
        foreach (ListItemData item in data)
            SetUpDataListItem(item, offset);
    }
    public virtual void PopulateSystemList(SystemBase[] systems)
    {
        float offset = -0.125f;
        foreach (SystemBase system in systems)
            SetUpSystemListItem(system, offset);
    }


    private void SetUpDataListItem(ListItemData item, float offset)
    {
        UIListItem model = SetUpListItem(offset);
        model.Populate(item);
    }
    private void SetUpSystemListItem(SystemBase system, float offset)
    {
        UIListItem model = SetUpListItem(offset);
        model.ConnectSystem(system);
    }
    private UIListItem SetUpListItem(float offset)
    {
        UIListItem model = Instantiate(ListItemModel, ScrollOffset);
        _listItems.Add(model);
        Vector3 pos = model.transform.localPosition;
        offset -= ListItemModel.Spacing;
        pos.y = offset;
        model.transform.localPosition = pos;
        return model;
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
    public override void SetColor(Color color)
    {
        Border.color = color;
        ScrollUp.SetColor(color);
        ScrollDown.SetColor(color);

        foreach (UIListItem listItem in _listItems)
            listItem.SetColor(color);
    }
}
