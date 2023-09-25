using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string _dataDirPath = "";

    private string _dataFileName = "";

    public FileDataHandler(string _dataDirPath, string _dataFileName) //constructor
    {
        this._dataDirPath = _dataDirPath;
        this._dataFileName = _dataFileName;
    }

    public GameData Load()
    {
        //diferentes sistemas operativos
        string fullPath = Path.Combine(_dataDirPath, _dataFileName); //ruta del archivo
        GameData _loadedData = null; //cargamos
        if(File.Exists(fullPath)) //checamos si el archivo existe
        {
            try
            {
                // cargar JSON String del archivo
                string _dataToLoad = ""; //para leerlo
                using (FileStream _stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader _reader = new StreamReader(_stream))
                    {
                        _dataToLoad = _reader.ReadToEnd(); //cargamos los datos en stream
                    }
                }
                //extraer de JSON String
                _loadedData = JsonUtility.FromJson<GameData>(_dataToLoad); //especificamos el tipo GameData que estan en JSON String en la variable _loadedData
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when trying to load data to file: " + fullPath + "\n" + e);
            }
        }

        return _loadedData;
    }

    public void Save(GameData _data)
    {
        //diferentes sistemas operativos
        string fullPath = Path.Combine(_dataDirPath, _dataFileName); //ruta del archivo
        try
        {
            //crear DirPath en casa de que no exista
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //GameData en un JSON string
            string _dataToStore = JsonUtility.ToJson(_data, true); //true para formatear

            //mandar los datos escritos del JSON string al archivo del sistema
            using(FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream)) 
                {
                    writer.Write(_dataToStore); //datod que queremos escribir
                }
            }


        }
        catch(Exception e)
        {
            Debug.LogError("Error occured when trying to save data to file: " + fullPath + "\n" + e);

        }
    }
}
