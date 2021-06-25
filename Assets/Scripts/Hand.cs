using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        KbKey key = other.GetComponent<KbKey>();
        if (key)
        {
            key.KeyClicked();
        }
    }
}
