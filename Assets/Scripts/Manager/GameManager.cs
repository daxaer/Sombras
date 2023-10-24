using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IDataPersiistence
{
    private int idioma;
    private bool pausa;
    private Transform spawnPlayer;
    private GameObject player;
    //Lenguaje
    [SerializeField] private const string LocaleKey = "SelectedKey";

    public static GameManager Instance;
    private ScriptableEstadisticas scriptable;

    private void Awake()
    {
        UnpauseGame();
        DontDestroyOnLoad(this);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
<<<<<<< HEAD
<<<<<<< HEAD
            Destroy(gameObject);
=======
            Destroy(Instance);
>>>>>>> parent of 7372f44 (projectil y rejugar)
=======
            Destroy(Instance);
>>>>>>> parent of 7372f44 (projectil y rejugar)
        }
    }
   
    private void Start()
    {
        int savedLocalID = PlayerPrefs.GetInt(LocaleKey, 0);
        ChangeLocal(savedLocalID);
        if(!DataPersistenceManager.Instance.HasGameData())
        {
            DataPersistenceManager.Instance.NewGame();
            Debug.Log("Creando Juego Nuevo");
        }
        else
        {
            //DataPersistenceManager.Instance.LoadGame();
        }
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
        pausa = true;
        Time.timeScale = 0;
    }
    public void UnpauseGame()
    {
        pausa = false;
        Time.timeScale = 1;
    }
    public void SetPlayer(GameObject _player )
    {
         player = _player ;
    }

    public GameObject PlayerSave()
    {
        return player;
    }

    public void SetScriptable(ScriptableEstadisticas _scriptable)
    {
        scriptable = _scriptable;
    }

    public ScriptableEstadisticas ScriptableSave()
    {
        return scriptable;
    }

<<<<<<< HEAD
<<<<<<< HEAD
    public void LoadData(GameData _data)
    {

    }

    public void SaveData(ref GameData _data)
    {
        _data.player = player;
        _data.estadisticas = scriptable;
    }
=======
>>>>>>> parent of 7372f44 (projectil y rejugar)
=======
>>>>>>> parent of 7372f44 (projectil y rejugar)
}
