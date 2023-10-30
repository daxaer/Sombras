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
    public GameObject player;

    //Guardado Estadisticas
    public float velocidadPlayer;
    public float vidaMaxima;
    public float vidaActual;
    public float ataque;
    public float rango;
    public float velocidadeAtaque;
    public float roboDeVida;
    public float duracionLamparas;
    public float rangoIluminacion;
    public ScriptableEstadisticas estadisticas;
    public int Almas;
    public int AlmasMax;

    //Pasivas
    public bool iluminarEnemigos;

    public GameData() // si se inicia un juego nuevo definimos las variable a valores iniciales por default, no hay dato que guardar si inicia
    {
        volumenMusic = -20;
        volumenEfectos = -20;
        rondaActual = 0;
        idioma = 0;
        player = null;

        //Guardado estadisticas public float velocidadPlayer;
        vidaMaxima = 0;
        vidaActual = 0;
        ataque = 0;
        rango = 0;
        velocidadeAtaque = 0;
        roboDeVida = 0;
        duracionLamparas = 0;
        rangoIluminacion = 0;
        estadisticas = null;

        //Pasivas
        iluminarEnemigos = false;
}
}
