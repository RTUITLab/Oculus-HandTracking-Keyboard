using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerTip : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var key = other.GetComponent<KbKey>();
        if (key)
        {
            key.KeyClicked();
        }
    }
}
