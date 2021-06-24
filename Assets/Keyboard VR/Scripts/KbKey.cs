using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[ExecuteInEditMode]
public class KbKey : MonoBehaviour
{
    [SerializeField] private Keys key;

    private Keyboard keyboard;
    private Text keyField;

    private void Start()
    {
        keyField = GetComponentInChildren<Text>();

        keyboard = GetComponentInParent<Keyboard>();
        keyboard.kbKeys.Add(this);
    }

    public void KeyClicked()
    {
        Debug.Log(key);
        switch (key)
        {
            case Keys.Symbol: // Standard key. Gets value from child's Text field.
                char symbol = keyField.text[0];
                keyboard.AddChar(symbol);
                break;
            case Keys.Enter:
                keyboard.AddChar('\n');
                break;
            case Keys.Space:
                keyboard.AddChar(' ');
                break;
            case Keys.Caps:
                keyboard.ToggleCaps();
                break;
            case Keys.Clear:
                keyboard.ClearAll();
                break;
            case Keys.Backspace:
                keyboard.RemoveChar();
                break;
            case Keys.SwitchLayout:
                keyboard.ChangeLayout();
                break;
        }
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Application.isEditor && !Application.isPlaying)
        {
            if (keyField)
            {
                gameObject.name = "Key_" + keyField.text; 

                if (key == Keys.Symbol && keyField.text.Length > 1)
                {
                    Debug.LogError($"{gameObject.name} can't have more than 1 char in text field when it works as Keys.Symbol");
                }
            }
        }
    }
#endif
}

public enum Keys
{
    None, Symbol, Enter, Space, Caps,
    Clear, Backspace, SwitchLayout
}
