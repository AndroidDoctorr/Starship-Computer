using Assets.Scripts;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class UIModal : UIElement
{
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

    public void Close()
    {
        SetMenuOpen(false);
    }

    private void ToggleMenu(string actionName, GameObject interactor)
    {
        SetMenuOpen(!IsOpen);
        OnToggle(IsOpen);
    }
    private void SetMenuOpen(bool isOpen)
    {
        IsOpen = isOpen;
        Content.SetActive(isOpen);
    }
}
