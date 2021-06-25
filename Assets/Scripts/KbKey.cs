using System.Collections;
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
    private bool canActivate = true;

    // Press Animation
    private readonly float pressSpeed = 25f;
    private readonly float returnSpeed = 15f;
    private readonly float travelDistance = 0.004f;
    private float defaultPosition;
    private float pressedPosition;

    private void Start()
    {
        defaultPosition = transform.localPosition.y;
        pressedPosition = defaultPosition - travelDistance;

        keyboard = GetComponentInParent<Keyboard>();
        keyboard.kbKeys.Add(this);
    }

    public void KeyClicked()
    {
        if (!canActivate) return;

        ClickAction();

        keyboard.PlayClickSound();
        StartCoroutine(ClickAnimation());
    }

    private void ClickAction()
    {
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
            case Keys.Tab:
                for (int i = 0; i < 4; i++)
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

    private IEnumerator ClickAnimation()
    {
        canActivate = false;
        Vector3 position = transform.localPosition;

        while (position.y > pressedPosition)
        {
            yield return new WaitForSeconds(0.02f);
            position.y -= pressSpeed * 0.00005f;
            transform.localPosition = position;   
        }

        position.y = pressedPosition;
        transform.localPosition = position;

        while (position.y < defaultPosition)
        {
            yield return new WaitForSeconds(0.02f);
            position.y += returnSpeed * 0.00005f;
            transform.localPosition = position;
        }

        position.y = defaultPosition;
        transform.localPosition = position;
        canActivate = true;
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Application.isEditor && !Application.isPlaying)
        {
            Canvas canvas = GetComponentInChildren<Canvas>();

            if (canvas)
            {
                canvas.name = "Canvas";
            }

            if (mainKey)
            {
                if (subKey)
                {
                    gameObject.name = "Key_" + mainKey.text + "-" + subKey.text;
                }
                else
                {
                    gameObject.name = "Key_" + mainKey.text;
                }

                if (key == Keys.Symbol && mainKey.text.Length > 1)
                {
                    Debug.LogError($"{gameObject.name} can't have more than 1 char in text field when it works as Keys.Symbol");
                }
            }
            else
            {
                if (canvas)
                {
                    if (canvas.transform.Find("Text"))
                    {
                        canvas.transform.Find("Text").TryGetComponent(out mainKey); // Shift, Enter, etc
                    }
                    else
                    {
                        canvas.transform.Find("Text Main").TryGetComponent(out mainKey); // Main key
                        canvas.transform.Find("Text Sub").TryGetComponent(out subKey); // Sub key
                    }
                }
            }
        }
    }
#endif
}

public enum Keys
{
    None, Symbol, Enter, Space, Caps,
    Clear, Backspace, Tab, SwitchLayout
}
