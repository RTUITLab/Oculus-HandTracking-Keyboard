using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour
{
    [HideInInspector] public List<KbKey> kbKeys;
    [Multiline] public string Text;
    private bool capsPressed = true;

    [SerializeField] private GameObject[] layouts;
    private int currentLayout = 0;

    [SerializeField] private GameObject layoutParent;

    private void Start()
    {
        foreach (var layout in layouts) layout.SetActive(false);
        layouts[currentLayout].SetActive(true);
    }

    public void Enable()
    {
        layoutParent.SetActive(true);
    }

    public void Disable()
    {
        layoutParent.SetActive(false);
    }

    #region Input

    public void AddChar(char input)
    {
        if (capsPressed)
        {
            Text += char.ToUpper(input);
        }
        else
        {
            Text += char.ToLower(input);
        }
    }

    public void RemoveChar()
    {
        Text = Text.Remove(Text.Length - 1);
    }

    public void ForceSetInput(string text)
    {
        Text = text;
    }
    public void ClearAll()
    {
        Text = "";
    }

    public void ToggleCaps()
    {
        capsPressed = !capsPressed;
    }

    #endregion

    #region Layouts

    public void ChangeLayout()
    {
        layouts[currentLayout].SetActive(false);
        currentLayout++;
        currentLayout %= layouts.Length;
        layouts[currentLayout].SetActive(true);
    }

    #endregion
}
