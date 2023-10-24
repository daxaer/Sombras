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
    public bool ataqueMele;
    [SerializeField] private MejorasPermanentes[] mejoraPermanente;
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
        vidaMaxima = personajeSeleccionado.VidaMaxima + mejoraPermanente[0].aumentoEstadistica;
        velocidadPlayer = personajeSeleccionado.VelocidadDeMovimiento + mejoraPermanente[3].aumentoEstadistica;
        vidaActual = personajeSeleccionado.vidaActual + mejoraPermanente[0].aumentoEstadistica;
        ataque = personajeSeleccionado.ATaque + mejoraPermanente[1].aumentoEstadistica;
        rango = personajeSeleccionado.RangoGolpe + mejoraPermanente[2].aumentoEstadistica;
        velocidadeAtaque = personajeSeleccionado.VelocidadDeAtaque;
        roboDeVida = personajeSeleccionado.PorcentajeRoboDeVida;
        duracionLamparas = personajeSeleccionado.TiempoIluminacion;
        rangoIluminacion = personajeSeleccionado.RangoIluminacion;
        bala = personajeSeleccionado.Bala;
        ataqueMele = personajeSeleccionado.AtaqueMele;
        
        //Pasivas
        iluminarEnemigos = true;
    }
}
