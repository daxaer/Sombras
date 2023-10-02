using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectedButton : MonoBehaviour
{
    [SerializeField] private GameObject boton;
    private void OnEnable()
    {
        EventSystem eventSystem = ManageEventSystem.Instance.GetEventSystem();
        eventSystem.SetSelectedGameObject(boton);
    }
}
