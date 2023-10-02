using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectedButton : MonoBehaviour
{
    [SerializeField] private GameObject boton;
    [SerializeField] private EventSystem eventSystem;

    private void OnEnable()
    {
        eventSystem.SetSelectedGameObject(boton);
    }
}
