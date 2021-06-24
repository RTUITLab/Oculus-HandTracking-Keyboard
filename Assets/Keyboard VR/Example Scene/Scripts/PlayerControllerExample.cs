using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerExample : MonoBehaviour
{
    [SerializeField] private GameObject keyPointerLeft;
    [SerializeField] private GameObject keyPointerRight;

    private void HideLasers()
    {
        if (keyPointerLeft) 
            keyPointerLeft.SetActive(false);

        if (keyPointerRight)
            keyPointerRight.SetActive(false);
    }
}
