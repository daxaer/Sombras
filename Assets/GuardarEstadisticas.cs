using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarEstadisticas : MonoBehaviour, IDataPersiistence
{
    public void LoadData(GameData _data)
    {

    }

    public void SaveData(ref GameData _data)
    {
        _data.player = GameManager.Instance.PlayerSave();
        _data.estadisticas = GameManager.Instance.ScriptableSave();
        //_data.rondaActual = 0;
    }
}
