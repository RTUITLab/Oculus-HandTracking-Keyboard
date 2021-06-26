using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] private AudioSource[] clicks;

    public void PlayClickSound()
    {
        int click = Random.Range(0, clicks.Length);
        clicks[click].Play();
    }
}
