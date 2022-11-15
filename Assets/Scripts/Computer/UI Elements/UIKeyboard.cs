using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIKeyboard : UIElement
{
    private Dictionary<string, string> ControlActions = new Dictionary<string, string>
    {
        { "x", "cut" },
        { "c", "copy" },
        { "v", "paste" },
        { "p", "print" },
        { "a", "all" },
        { "z", "undo" },
        { "o", "open" },
        { "s", "save" },
        { "q", "quit" },
        { "l", "load" },
        { "h", "help" },
        { "m", "mute" },
        { "1", "F1" },
        { "2", "F2" },
        { "3", "F3" },
        { "4", "F4" },
        { "5", "F5" },
        { "6", "F6" },
        { "7", "F7" },
        { "8", "F8" },
        { "9", "F9" },
        { "0", "F10" },
    };
    private List<string> Characters = new List<string>() {
        "1","2","3","4","5","6","7","8","9","0",
        "a","b","c","d","e","f","g","h","i","j","k","l","m",
        "n","o","p","q","r","s","t","u","v","w","x","y","z",
        ".",",","-","/","'"
    };
    private List<string> ShiftCharacters = new List<string>() {
        "!","?","#","@","%","^","&","*","(",")",
        "A","B","C","D","E","F","G","H","I","J","K","L","M",
        "N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
        ":",";","_","+","\""
    };

    private bool _shiftPressed = false;
    private bool _controlPressed = false;
    private bool _capsOn = false;
    private AudioSource _as;

    public UIButton[] Keys;
    public Color Color = new Color(1, 0.6666667f, 0);
    public Color BackgroundColor = new Color(0, 0, 0);
    public Image Background;
    public Image Border;
    public AudioClip[] SoundEffects;

    public delegate void OnKeyOut(string action, char character);
    public event OnKeyOut onKeyOut;

    void Start()
    {
        foreach (UIButton key in Keys)
        {
            key.onButtonPress += KeyPress;
            if (key.ActionName == "KeyShift" || key.ActionName == "KeyControl")
            {
                key.onButtonExit += ExitPress;
            }
        }

        _as = GetComponent<AudioSource>();
    }
    void Update()
    {
        
    }

    public void DoError()
    {
        _as.Stop();
        PlaySound(4);
    }
    private void KeyPress(string actionName, GameObject hand)
    {
        if (!actionName.StartsWith("Key"))
        {
            Debug.LogError($"Invalid UI Keyboard Key Press: {actionName}");
            return;
        }
        // Get the name of the action or character
        string action = actionName.Substring(3).ToLower();
        // Determine if it's a control action
        if (_controlPressed && ControlActions.ContainsKey(action))
            KeyOut(ControlActions[action], '~');
        // Determine if character keypress or action
        else if (Characters.Contains(action))
            TypeCharacter(action);
        else
            DoKeyAction(action);
    }
    private void TypeCharacter(string charString)
    {
        PlaySound(1);
        // Use "capital" version
        if ((_capsOn && !_shiftPressed) || (!_capsOn && _shiftPressed))
        {
            int index = Characters.IndexOf(charString);
            string shiftChar = ShiftCharacters[index];
            KeyOut("char", shiftChar[0]);
        }
        else
            // Use "lowercase" version
            KeyOut("char", charString[0]);
    }
    private void DoKeyAction(string action)
    {
        switch (action)
        {
            // Keyboard actions
            case "space":
                PlaySound(3);
                KeyOut("char", ' ');
                break;
            case "shift":
                _shiftPressed = true;
                break;
            case "caps":
                _capsOn = !_capsOn;
                break;
            case "control":
                _controlPressed = true;
                break;
            // Outside actions
            case "enter":
                PlaySound(2);
                break;
            case "backspace":
            case "clear":
                PlaySound(0);
                KeyOut(action, '~');
                break;
            default:
                KeyOut(action, '~');
                break;
        }
    }
    private void ExitPress(string actionName, GameObject hand)
    {
        if (actionName == "KeyShift")
            _shiftPressed = false;
        else if (actionName == "KeyControl")
            _controlPressed = false;
    }
    private void KeyOut(string action, char character)
    {
        if (onKeyOut != null) onKeyOut(action, character);
    }

    private void PlaySound(int clipId)
    {
        _as.clip = SoundEffects[clipId];
        _as.PlayDelayed(0);
    }
    public override void SetColor(Color color)
    {
        foreach (UIButton key in Keys)
            key.SetColor(color);
        Border.color = color;
    }
}
