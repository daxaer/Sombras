using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    Controles control;
    private void Awake()
    {
        control = new Controles();
    }

    private void OnEnable()
    {
        control.Gameplay.Enable();
        control.Gameplay.Movimiento.performed += movimiento;
        control.Gameplay.Movimiento.canceled += movimiento;
        //control.Gameplay.Atacar.started += atacar;
       
    }

    //private void atacar(InputAction.CallbackContext obj)
    //{
    //    FindAnyObjectByType<Ataque>().Atacar();
    //}

    private void movimiento(InputAction.CallbackContext obj)
    {
        Vector2 moveDir = obj.ReadValue<Vector2>();

        FindAnyObjectByType<MovimientoPersonaje>().moveDir(moveDir);
    }
}
