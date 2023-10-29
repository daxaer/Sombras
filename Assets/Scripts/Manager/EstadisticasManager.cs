using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EstadisticasManager : MonoBehaviour, IDataPersiistence
{

    public float velocidadPlayer;
    public int vidaMaxima;
    public int vidaActual;
    public float ataque;
    public float rango;
    public float velocidadeAtaque;
    public float roboDeVida;
    public float duracionLamparas;
    public float rangoIluminacion;
    public GameObject bala;
    public bool ataqueMele;
    [SerializeField] private MejorasPermanentes[] mejorasPermanentes;

    //Pasivas
    public bool pasivaIluminacion;

    [SerializeField] private ScriptableEstadisticas personajeSeleccionado;
    public static EstadisticasManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    public void LoadData(GameData _data)
    {
        personajeSeleccionado = _data.estadisticas;
        if(_data.rondaActual > 0)
        {
            bala = personajeSeleccionado.Bala;
            ataqueMele = personajeSeleccionado.AtaqueMele;
            vidaMaxima = _data.vidaMaxima;
            velocidadPlayer = _data.velocidadPlayer;
            vidaActual = _data.vidaActual;
            ataque = _data.ataque;
            rango = _data.rango;
            velocidadeAtaque = _data.velocidadeAtaque;
            roboDeVida = _data.roboDeVida;
            duracionLamparas = _data.duracionLamparas;
            rangoIluminacion = _data.rangoIluminacion;

            //Pasivas
            pasivaIluminacion = _data.iluminarEnemigos;
        }
        else
        {
            vidaMaxima = personajeSeleccionado.VidaMaxima + (int)mejorasPermanentes[0].AumentoEstadistica;
            velocidadPlayer = personajeSeleccionado.VelocidadDeMovimiento + (int)mejorasPermanentes[1].AumentoEstadistica; ;
            vidaActual = personajeSeleccionado.vidaActual + (int)mejorasPermanentes[0].AumentoEstadistica; ;
            ataque = personajeSeleccionado.Ataque + (int)mejorasPermanentes[2].AumentoEstadistica; ;
            rango = personajeSeleccionado.ProjectileSize + (int)mejorasPermanentes[3].AumentoEstadistica; ;
            velocidadeAtaque = personajeSeleccionado.VelocidadDeAtaque + (int)mejorasPermanentes[4].AumentoEstadistica; ;
            roboDeVida = personajeSeleccionado.PorcentajeRoboDeVida + (int)mejorasPermanentes[5].AumentoEstadistica; ;
            duracionLamparas = personajeSeleccionado.TiempoIluminacion;
            rangoIluminacion = personajeSeleccionado.RangoIluminacion;
            bala = personajeSeleccionado.Bala;
            ataqueMele = personajeSeleccionado.AtaqueMele;


            //Pasivas
            pasivaIluminacion = personajeSeleccionado.Iluminar;
        }
    }

    public void SaveData(ref GameData _data)
    {
        _data.vidaMaxima = vidaMaxima;
        _data.velocidadPlayer = velocidadPlayer;
        _data.vidaActual = vidaActual;
        _data.ataque = ataque;
        _data.rango = rango;
        _data.velocidadeAtaque = velocidadeAtaque;
        _data.roboDeVida = roboDeVida;
        _data.duracionLamparas = duracionLamparas;
        _data.rangoIluminacion = rangoIluminacion;

        //Pasivas
        _data.iluminarEnemigos = pasivaIluminacion;
    }
}
