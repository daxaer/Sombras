using System.Collections;
using System.Collections.Generic;
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
            vidaMaxima = personajeSeleccionado.VidaMaxima;
            velocidadPlayer = personajeSeleccionado.VelocidadDeMovimiento;
            vidaActual = personajeSeleccionado.vidaActual;
            ataque = personajeSeleccionado.Ataque;
            rango = personajeSeleccionado.RangoGolpe;
            velocidadeAtaque = personajeSeleccionado.VelocidadDeAtaque;
            roboDeVida = personajeSeleccionado.PorcentajeRoboDeVida;
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
