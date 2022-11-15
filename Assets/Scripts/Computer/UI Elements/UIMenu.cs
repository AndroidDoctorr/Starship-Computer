using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : UIElement
{
    public UIButton[] MenuButtons;
    public GenericUI[] MenuScreens;
    public UIButton RedAlertButton;
    public RectTransform Selector;
    public string Name;
    void Start()
    {
        RedAlertButton.onButtonPress += ToggleRedAlert;

        if (MenuButtons.Length != MenuScreens.Length)
            Debug.LogError("UI Menu supplied with different numbers of toggles and UIs");

        foreach (UIButton button in MenuButtons)
            button.onButtonPress += SelectMenuItem;
    }

    void Update()
    {

    }
    private void SelectMenuItem(string action, GameObject hand)
    {
        int index;
        bool isValid = int.TryParse(action, out index);
        if (isValid) ShowUIAtIndex(index);
        Selector.transform.localPosition = new Vector3(6, 25 - 10 * index, 0);
    }
    private void ShowUIAtIndex(int index)
    {
        if (index < 0) return;
        if (index >= MenuScreens.Length) return;
        for (int i = 0; i < MenuScreens.Length; i++)
        {
            GenericUI ui = MenuScreens[i];
            ui.gameObject.SetActive(i == index);
        }
    }
    private void ToggleRedAlert(string action, GameObject hand)
    {
        // MainComputer.ToggleRedAlert();
    }
    public override void SetColor(Color color)
    {
        foreach (UIButton button in MenuButtons)
            button.SetColor(color);
        foreach (GenericUI ui in MenuScreens)
            ui.SetColor(color);
        foreach (Image image in GetComponentsInChildren<Image>())
            image.color = color;
    }
}
