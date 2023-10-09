using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;
    [SerializeField] Tarjeta tarjeta;
    private int idioma;
    //Lenguaje
    [SerializeField] private const string LocaleKey = "SelectedKey";
    public string[] palabra;
    public static GameManager Instance { get; private set; }

    //deativate butons after click
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _continueGameButton;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    private void Start()
    {
        int savedLocalID = PlayerPrefs.GetInt(LocaleKey, 0);
        ChangeLocal(savedLocalID);

        //check if doesnt has data for disable the button
        if(!DataPersistenceManager.Instance.HasGameData())
        {
            _continueGameButton.interactable = false;
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

    //Lenguaje
    public void ChangeLocal(int localID)
    {
        var avaliableLocales = LocalizationSettings.AvailableLocales;
        if (localID >= 0 && localID < avaliableLocales.Locales.Count)
        {
            LocalizationSettings.SelectedLocale = avaliableLocales.Locales[localID];
            PlayerPrefs.SetInt(LocaleKey, localID);
            idioma = localID;
        }
    }

    public int ChangeLenguageTarget()
    {
        return idioma;
    }

    public void OnContinueCliked()
    {
        DisableMenuButtons();
        //Load the scene - and save our game because the OnSceneUnload() is in the prefab DataPersistenceManager
        SceneManager.LoadSceneAsync("Game"); //load our preexistence data
    }

    public void OnNewGameCliked()
    {
        DisableMenuButtons();
        //intialize our game data
        DataPersistenceManager.Instance.NewGame(); //keep data outside the application when transition to other scene
        //Load the scene - and save our game because the OnSceneUnload() is in the prefab DataPersistenceManager
        SceneManager.LoadSceneAsync("Game");
        
    }

    private void DisableMenuButtons()
    {
        _newGameButton.interactable = false;
        _continueGameButton.interactable = false;
    }
}
