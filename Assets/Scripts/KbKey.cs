﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[ExecuteInEditMode]
public class KbKey : MonoBehaviour
{
    [SerializeField] private Keys key;

    // If key = Keys.Symbol
    private Text mainKey;
    private Text subKey;

    private Keyboard keyboard;

    private void Start()
    {
        Canvas canvas = GetComponentInChildren<Canvas>();
        mainKey = canvas.transform.Find("Text").GetComponent<Text>(); // Shift, Enter, etc
        mainKey = canvas.transform.Find("Text Main").GetComponent<Text>(); // Main key
        subKey = canvas.transform.Find("Text Sub").GetComponent<Text>(); // Sub key

        keyboard = GetComponentInParent<Keyboard>();
        keyboard.kbKeys.Add(this);
    }

    public void KeyClicked()
    {
        Debug.Log(key);
        switch (key)
        {
            case Keys.Symbol: // Standard key. Gets value from child's Text field.
                char symbol;
                if (keyboard.IsMainLayout)
                    symbol = mainKey.text[0];
                else
                    symbol = subKey.text[0];
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
            if (mainKey)
            {
                gameObject.name = "Key_" + mainKey.text; 

                if (key == Keys.Symbol && mainKey.text.Length > 1)
                {
                    Debug.LogError($"{gameObject.name} can't have more than 1 char in text field when it works as Keys.Symbol");
                }
            } else
            {
                Canvas canvas = GetComponentInChildren<Canvas>();
                mainKey = canvas.transform.Find("Text").GetComponent<Text>(); // Shift, Enter, etc
                mainKey = canvas.transform.Find("Text Main").GetComponent<Text>(); // Main key
                subKey = canvas.transform.Find("Text Sub").GetComponent<Text>(); // Sub key
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