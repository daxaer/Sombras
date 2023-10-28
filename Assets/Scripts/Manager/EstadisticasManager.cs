using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EstadisticasManager : MonoBehaviour, IDataPersiistence
{
    private bool saveGame;

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
    public bool iluminarEnemigos;

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
        personajeSeleccionado = GameManager.Instance.ScriptableSave();
    }

    private void Start()
    {
        if(saveGame)
        {
            bala = personajeSeleccionado.Bala;
            ataqueMele = personajeSeleccionado.AtaqueMele;
        }
        else{
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
            iluminarEnemigos = personajeSeleccionado.Iluminar;
        }
    }

    public void LoadData(GameData _data)
    {
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
        iluminarEnemigos = _data.iluminarEnemigos;
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
        _data.iluminarEnemigos = iluminarEnemigos;
    }
}
