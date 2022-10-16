using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITextInput : UIElement
{
    private string _inputString;
    private float _timeTilEnter = 0;

    public UIKeyboard Keyboard;
    public Image Border;
    public TMP_Text Text;
    public float DebounceDelay = 0.5f;
    public int InputLimit = 24;

    public delegate void OnInputChange(string textInput);
    public event OnInputChange onInputChange;
    void Start()
    {
        Keyboard.onKeyOut += KeyPressAction;
        Text.text = "";
        _inputString = "";
    }
    void Update()
    {
        if (_timeTilEnter > 0)
        {
            _timeTilEnter -= Time.deltaTime;
            if (_timeTilEnter <= 0)
                onInputChange(_inputString);
        }
    }
    private void KeyPressAction(string action, char key)
    {
        Debug.Log($"Key press action: {action}");
        // String actions
        if (action == "char")
            DoChar(key);
        else if (action == "clear")
            _inputString = "";
        else if (action == "backspace")
            DoBackspace();
        else if (action == "enter")
            onInputChange(_inputString);
        // Updatet the text display
        Text.text = _inputString;
        _timeTilEnter = DebounceDelay;
    }
    private void DoChar(char key)
    {
        if (_inputString.Length < InputLimit)
            _inputString += key;
        else
            Keyboard.DoError();
    }
    private void DoBackspace()
    {
        if (_inputString.Length > 0)
            _inputString = _inputString.Substring(0, _inputString.Length - 1);
        else
            Keyboard.DoError();
    }
    public override void SetColor(Color color)
    {
        Keyboard.SetColor(color);
        Border.color = color;
    }
}
