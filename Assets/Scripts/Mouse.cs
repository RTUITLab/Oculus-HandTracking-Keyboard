using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] private AudioSource click;
    [SerializeField] private Keyboard keyboard;

    public void KeyClicked()
    {
        keyboard.JokeTyping = !keyboard.JokeTyping;

        PlayClickSound();
    }

    private void PlayClickSound()
    {
        click.pitch = Random.Range(0.96f, 1.04f);
        click.Play();
    }
}
