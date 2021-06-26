using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour
{
    [HideInInspector] public List<KbKey> kbKeys;
    [Multiline] public string Text;
    public bool IsCapsPressed = true;
    public bool IsMainLayout = true; // English, else Russian

    [SerializeField] private AudioSource[] clicks; 

    public void AddChar(char input)
    {
        if (IsCapsPressed)
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
        IsCapsPressed = !IsCapsPressed;
    }

    public void ChangeLayout()
    {
        IsMainLayout = !IsMainLayout;
    }


    public void PlayClickSound()
    {
        int click = Random.Range(0, clicks.Length);
        clicks[click].Play();
    }
}
