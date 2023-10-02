using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    Controles control;
    public static InputManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
        control = new Controles();
    }

    private void OnEnable()
    {
        control.Gameplay.Enable();
        control.Gameplay.Atacar.started += atacar;
        control.Gameplay.Pause.started -= Pause;
    }

    private void OnDisable()
    {
        control.Gameplay.Disable();
        control.Gameplay.Atacar.started -= atacar;
        control.Gameplay.Pause.started -= Pause;
    }

    private void atacar(InputAction.CallbackContext obj)
    {
        FindAnyObjectByType<Ataque>().Atacar();
    }

    private void Pause(InputAction.CallbackContext obj)
    {
        ManageScenes.Instance.AbrirPausa();
    }

}
