using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class UIPopupMenu : UIElement
{
    private bool _isTouching = false;

    public bool IsOpen = false;
    public UIButton MenuToggle;
    public GameObject CloseMenuIcon;
    public GameObject OpenMenuIcon;
    public GameObject Menu;
    public Image OutlineArea;
    public Image BackgroundArea;
    public ScrollView ScrollView;
    public GameObject Content;

    public delegate void OnToggleDelegate(bool isOpen);
    public event OnToggleDelegate OnToggle;

    void OnEnable()
    {
        MenuToggle.onButtonPress += ToggleMenu;
        MenuToggle.onButtonPress += EndTouch;
        if (IsOpen) SetMenuOpen(true);
    }
    void OnDestroy()
    {
        MenuToggle.onButtonPress -= ToggleMenu;
        MenuToggle.onButtonPress -= EndTouch;
    }
    private void ToggleMenu(string actionName, GameObject interactor)
    {
        if (_isTouching) return;
        _isTouching = true;

        OnToggle(!IsOpen);

        if (IsOpen) SetMenuOpen(false);
        else SetMenuOpen(true);
    }
    private void EndTouch(string actionName, GameObject interactor)
    {
        _isTouching = false;
    }
    private void SetMenuOpen(bool isOpen)
    {
        IsOpen = isOpen;

        Menu.SetActive(isOpen);
        CloseMenuIcon.SetActive(isOpen);
        OpenMenuIcon.SetActive(!isOpen);
    }
}
