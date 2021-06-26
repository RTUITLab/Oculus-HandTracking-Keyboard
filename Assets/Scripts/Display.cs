using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private Keyboard keyboard;

    private void Update()
    {
        inputField.text = keyboard.Text;
    }
}
