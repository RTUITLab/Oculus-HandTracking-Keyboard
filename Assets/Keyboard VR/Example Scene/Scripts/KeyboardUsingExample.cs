using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardUsingExample : MonoBehaviour
{
    [SerializeField] private Keyboard keyboard; // Cсылка на клавиатуру.
    [SerializeField] private InputField inputField; // Куда будем выводить текст.

    private void Update()
    {
        string text = keyboard.Text; // Получение введенного текста.

        inputField.text = text; // В данном примере просто выводим его на экран.
    }

    private void Usages()
    {
        keyboard.Enable(); // Включение клавиатуры вместе с лазерами для ввода.

        keyboard.Disable(); // Выключение клавиатуры вместе с лазерами для ввода.

        keyboard.ClearAll(); // Очистка всего с клавиатуры.

        keyboard.ForceSetInput("Новый текст"); // Замена текста на указанный.
    }

    /// <summary>
    /// Метод, вызываемый по нажатию на Enter в Single Line Field
    /// </summary>
    public void OnClickSave()
    {
        Debug.LogWarning("Метод сохранения текста не реализован!");
    }
}
