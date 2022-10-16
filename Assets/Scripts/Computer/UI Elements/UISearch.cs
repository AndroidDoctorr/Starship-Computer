using Assets.Scripts;
using UnityEngine;

public class UISearch : UIElement
{
    public UITextInput TextInput;

    public delegate void SearchHandler(string searchString);
    public event SearchHandler onSearch;

    void Start()
    {
        TextInput.onInputChange += SearchByString;
        TextInput.Text.text = "Search";
    }

    private void SearchByString(string searchString)
    {
        if (onSearch != null) onSearch(searchString);
    }
    public override void SetColor(Color color)
    {
        TextInput.SetColor(color);
    }
}
