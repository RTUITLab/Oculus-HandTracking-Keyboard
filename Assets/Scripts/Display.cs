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

        if (keyboard.JokeTyping)
            info.text = "PRO MODE";
        else
            info.text = $"{(keyboard.IsCapsPressed ? "CAPS" : "")}   {(keyboard.IsMainLayout ? "ENG" : "РУС")}";
    }
}
