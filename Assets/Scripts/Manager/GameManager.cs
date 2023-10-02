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
    private int idioma;
    private bool pausa;
    private Transform spawnPlayer;
    //Lenguaje
    [SerializeField] private const string LocaleKey = "SelectedKey";

    public static GameManager Instance;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (Instance == null)
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

    public void JuegoPausado()
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
}
