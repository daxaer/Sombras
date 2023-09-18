using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;

    //Lenguaje
    [SerializeField] private const string LocaleKey = "SelectedKey";
    public string[] palabra;
    public static GameManager Instance { get; private set; }
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
        }
    }
}
