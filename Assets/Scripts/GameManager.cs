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
    private int idioma;
    private bool pausa;
    [SerializeField] private ScriptableEstadisticas jugador;
    private Transform spawnPlayer;
    //Lenguaje
    [SerializeField] private const string LocaleKey = "SelectedKey";
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        DontDestroyOnLoad(this);
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

    public void GamePaused()
    {
        pausa = !pausa;
        if(pausa)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void SelectedChamp(ScriptableEstadisticas _jugador)
    {
        jugador = _jugador;
    }

    public ScriptableEstadisticas Player()
    {
        return jugador;
    }
}
