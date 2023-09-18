using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Hay mas de un game manager");
        }
    }
    public void AbrirMenu(GameObject menu,GameObject selectedButton)
    {
        menu.SetActive(true);
        eventSystem.SetSelectedGameObject(selectedButton);
    }

    public void CerrarMenu(GameObject menu)
    {
        menu.SetActive(false);
    }

    public void LoadScene(string nombreScena)
    {
        SceneManager.LoadSceneAsync(nombreScena, LoadSceneMode.Single);
    }
}
