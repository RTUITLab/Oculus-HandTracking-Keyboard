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
        inputField.text = keyboard.Text;

        info.text = $"{(keyboard.IsCapsPressed ? "CAPS" : "")}   {(keyboard.IsMainLayout ? "ENG" : "RUS")}";
    }
}
