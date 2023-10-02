using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;

    public static ManageScenes Instance;

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
    }

    public void AbrirMenu(GameObject menu)
    {
        menu.SetActive(true);
    }
    public void SeleccionarBoton(GameObject selectedButton)
    {
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

    public void Exit()
    {
        Application.Quit();
    }
}
