using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    private GameData _gameData;
    private List<IDetaPersiistence> _dataPersistenceObjects;
    public static DataPersistenceManager Instance { get; private set; } //solo esta clase
    [SerializeField] private string _fileName; //nombre de archivo para guardar los datos
    private FileDataHandler _fileDataHandler;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one Data Persistence Manager in the scene");
        }
        Instance = this;
    }

    private void Start()
    {
        this._fileDataHandler = new FileDataHandler(Application.persistentDataPath, _fileName); //directory y nombre del archivo, conservar los datado en el proyecto
        this._dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this._gameData = new GameData();
    }

    public void LoadGame()
    {
        //Usar data handler para cargar cualquier savedata de una fila
        this._gameData = _fileDataHandler.Load(); //si es null no existe, entonces creamos un nuevo juego;

        //si no hay datos que cargar, iniciar nuevo juego
        if(this._gameData == null)
        {
            Debug.Log("No data was found. Initializing data to defaults.");
            NewGame();
        }

        //enviar datos guardados a los scripts
        foreach(IDetaPersiistence _dataPersistenceObj in _dataPersistenceObjects)//recorrer todos los objectos de Idetapersiistence en la lista
        {
            _dataPersistenceObj.LoadData(_gameData); //los encontramos y pasamos el GameData
        }
        Debug.Log("Loaded death count = " + _gameData._deathCount);
    }

    public void SaveGame()
    {
        // pasar los datos a otros scripts para que puedan actualizarlos
        foreach (IDetaPersiistence _dataPersistenceObj in _dataPersistenceObjects)//recorrer todos los objectos de Idetapersiistence en la lista
        {
            _dataPersistenceObj.SaveData(ref _gameData); //los encontramos y pasamos el GameData
        }
        Debug.Log("Saved death count = " + _gameData._deathCount);

        //Guardamos los datos en un archivo utilizando el DataHandler
        _fileDataHandler.Save(_gameData); //le pasamos los nuevos datos de juego que se guardaran
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDetaPersiistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDetaPersiistence> _dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDetaPersiistence>();

        return new List<IDetaPersiistence>( _dataPersistenceObjects);
    }
}
