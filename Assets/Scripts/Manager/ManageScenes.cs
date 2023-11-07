using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;
    [SerializeField] bool gameSave;
    [SerializeField] private GameObject pausa;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject transition;
    public static ManageScenes Instance;
    [SerializeField] private ChangScene changeScene; 

    private void Awake()
    {
        Instance = this;
        /*
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }*/
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
        //SceneManager.LoadSceneAsync(nombreScena, LoadSceneMode.Single);
        changeScene.SceneToCall(nombreScena);
        transition.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void AbrirWin()
    {
        win.SetActive(true);
    }
    public void AbrirGameOver()
    {
        gameOver.SetActive(true);
    }
    public void AbrirPausa()
    {
        pausa.SetActive(true);
    }

    public void PauseGame()
    {
        GameManager.Instance.UnpauseGame();
    }
    public void activePlayer(GameObject player)
    {
        GameManager.Instance.SetPlayer(player);
    }
    public void ActiveScriptable(ScriptableEstadisticas scriptable)
    {
        GameManager.Instance.SetScriptable(scriptable);
    }

    public void NewSavegame()
    {
        gameSave = true;
    }
}

