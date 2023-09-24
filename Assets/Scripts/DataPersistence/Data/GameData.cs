using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int _deathCount;

    public GameData() // si se inicia un juego nuevo definimos las variable a valores iniciales por default, no hay dato que guardar si inicia
    {
        this._deathCount = 0;
    }
}
