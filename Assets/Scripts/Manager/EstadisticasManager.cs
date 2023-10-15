using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EstadisticasManager : MonoBehaviour
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
        vidaMaxima = personajeSeleccionado.VidaMaxima;
        velocidadPlayer = personajeSeleccionado.VelocidadDeMovimiento;
        vidaActual = personajeSeleccionado.vidaActual;
        ataque = personajeSeleccionado.ATaque;
        rango = personajeSeleccionado.RangoGolpe;
        velocidadeAtaque = personajeSeleccionado.VelocidadDeAtaque;
        roboDeVida = personajeSeleccionado.PorcentajeRoboDeVida;
        duracionLamparas = personajeSeleccionado.TiempoIluminacion;
        rangoIluminacion = personajeSeleccionado.RangoIluminacion;
        bala = personajeSeleccionado.Bala;
        
        //Pasivas
        iluminarEnemigos = true;
    }

    private void InterpolationCubicRound()
    {

    }
}
