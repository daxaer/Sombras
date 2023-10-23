using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersiistence
{
    void LoadData(GameData _data); //el script de implementacion solo se encarga de leer datos
    void SaveData(ref GameData _data); //ref para modificar datos desde otro script de implementacion
}
