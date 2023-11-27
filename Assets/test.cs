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
            Timer.Instance._timeRemaining = 1;
        }
        if (Keyboard.current.lKey.isPressed)
        {
            Timer.Instance.rondaActual = 9;
        }
        if (Keyboard.current.oKey.isPressed)
        {
            EstadisticasManager.Instance.vidaActual = 0;
            UIManager.Instance.UpdateVida();
        }
    }
}
