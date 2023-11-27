using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class test : MonoBehaviour
{

    public void Update()
    {
        if (Keyboard.current.pKey.isPressed) 
        {
            Timer.Instance._timeRemaining = 3;
        }
    }
}
