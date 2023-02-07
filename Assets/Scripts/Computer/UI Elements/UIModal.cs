using Assets.Scripts;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class UIModal : UIElement
{
    private bool _isTouching = false;

    public bool IsOpen { get; private set; } = false;
    public UIButton MenuToggle;
    public Image OutlineArea;
    public Image BackgroundArea;
    public Image Backdrop;
    public GameObject Content;
    public bool StartOpen = false;

    public delegate void OnToggleDelegate(bool isOpen);
    public event OnToggleDelegate OnToggle;

    void OnEnable()
    {
        MenuToggle.onButtonPress += ToggleMenu;
        if (StartOpen) SetMenuOpen(true);
    }
    void OnDestroy()
    {
        MenuToggle.onButtonPress -= ToggleMenu;
    }
    private void ToggleMenu(string actionName, GameObject interactor)
    {
        if (_isTouching) return;
        _isTouching = true;

        OnToggle(!IsOpen);

        if (IsOpen) SetMenuOpen(false);
        else SetMenuOpen(true);
    }
    private void SetMenuOpen(bool isOpen)
    {
        IsOpen = isOpen;

        Content.SetActive(isOpen);
    }
}
