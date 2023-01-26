using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;
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



    private void PopulateList(ListItemData[] data)
    {
        float offset = 0;
        foreach (ListItemData item in data)
        {
            UIListItem model = Instantiate(ListItemModel);
            model.Populate(item);
            _listItems.Add(model);
            offset -= ListItemModel.Height;
        }
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
