using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("Debugging")]
    [SerializeField] private bool _initializeDataIfNull = false;

    [Header("File Storage Config")]
    private GameData _gameData;
    private List<IDataPersiistence> _dataPersistenceObjects;
    public static DataPersistenceManager Instance { get; private set; } //solo esta clase
    [SerializeField] private string _fileName; //nombre de archivo para guardar los datos
    [SerializeField] private bool _useEncryption;
    private FileDataHandler _fileDataHandler;
    private void Awake()
    {
        if (Instance != null)
        {
            //Debug.LogError("Found more than one Data Persistence Manager in the scene. Destroying the newest one");
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        this._fileDataHandler = new FileDataHandler(Application.persistentDataPath, _fileName, _useEncryption); //directory y nombre del archivo, conservar los datado en el proyecto de unity
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded Called");
        this._dataPersistenceObjects = FindAllDataPersistenceObjects(); //reset list objects, then load
        LoadGame();
    }

    public void OnSceneUnloaded(Scene scene)
    {
        Debug.Log("OnSceneUnloaded Called");
        SaveGame();
    }

    public void NewGame()
    {
        this._gameData = new GameData();
    }

    public void LoadGame()
    {
        //Usar data handler para cargar cualquier savedata de una fila
        this._gameData = _fileDataHandler.Load(); //si es null no existe, entonces creamos un nuevo juego;

        //new game for develop purposes
        if(this._gameData == null && _initializeDataIfNull)
        {
            NewGame();
        }

        //si no hay datos que cargar, iniciar nuevo juego
        if(this._gameData == null)
        {
            Debug.Log("No data was found. A New Game needs to be started before data can be loaded");
            return;
        }

        //enviar datos guardados a los scripts
        foreach(IDataPersiistence _dataPersistenceObj in _dataPersistenceObjects)//recorrer todos los objectos de Idetapersiistence en la lista
        {
            _dataPersistenceObj.LoadData(_gameData); //los encontramos y pasamos el GameData
        }
    }

    public void SaveGame()
    {
        //if we wont any data to save
        if(this._gameData == null)
        {
            Debug.LogWarning("No data was found. A New Game need to be started before data can be saved");
            return;
        }

        // pasar los datos a otros scripts para que puedan actualizarlos
        foreach (IDataPersiistence _dataPersistenceObj in _dataPersistenceObjects)//recorrer todos los objectos de Idetapersiistence en la lista
        {
            _dataPersistenceObj.SaveData(ref _gameData); //los encontramos y pasamos el GameData
        }

        //Guardamos los datos en un archivo utilizando el DataHandler
        _fileDataHandler.Save(_gameData); //le pasamos los nuevos datos de juego que se guardaran
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersiistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersiistence> _dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersiistence>();

        return new List<IDataPersiistence>( _dataPersistenceObjects);
    }

    public bool HasGameData()
    {
        return _gameData != null;
    }
}
