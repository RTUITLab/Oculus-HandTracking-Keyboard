using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    [SerializeField] private Keyboard keyboard;
    [SerializeField] private InputField inputField;
    [SerializeField] private Text info;

    private void Update()
    {
        // Ah yes, Update for this. Just because this isn't so important but will take some time for right solution.
        inputField.text = keyboard.Text;

        if (keyboard.JokeTyping) {
            info.text = "PRO MODE";
        }
        else {
            if (!keyboard.IsShiftPressed) // Display shift or caps only, not both
                info.text = "SHIFT   ";
            else
                info.text = $"{(keyboard.IsCapsPressed ? "CAPS" : "")}   ";


            info.text += $"{(keyboard.IsMainLayout ? "ENG" : "РУС")}";
        }
    }
}
