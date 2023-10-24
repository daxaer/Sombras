using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float volumenMusic;
    public float volumenEfectos;
    public int rondaActual;
    public int idioma;
    public ScriptableEstadisticas estadisticas;
    public GameObject player;


    public GameData() // si se inicia un juego nuevo definimos las variable a valores iniciales por default, no hay dato que guardar si inicia
    {
        volumenMusic = -20;
        volumenEfectos = -20;
        rondaActual = 0;
        idioma = 0;
        estadisticas = null;
        player = null;
    }
}
