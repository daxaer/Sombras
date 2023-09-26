using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estadisticas : MonoBehaviour
{
    // Start is called before the first frame update

    public float velocidadPlayer;
    public float vidaMaxima;
    public float vidaActual;
    public float ataque;
    public float rango;
    public float VelocidadeAtaque;
    public float roboDeVida;
    public float duracionLamparas;
    public float rangoIluminacion;

    //Pasivas
    public bool iluminarEnemigos;


    [SerializeField] private ScriptableEstadisticas personajeSeleccionado;

    private void Start()
    {
        vidaMaxima = personajeSeleccionado.VidaMaxima;
        velocidadPlayer = personajeSeleccionado.VelocidadDeMovimiento;
        vidaActual = personajeSeleccionado.vidaActual;
        ataque = personajeSeleccionado.ATaque;
        rango = personajeSeleccionado.RangoGolpe;
        VelocidadeAtaque = personajeSeleccionado.VelocidadDeAtaque;
        roboDeVida = personajeSeleccionado.PorcentajeRoboDeVida;
        duracionLamparas = personajeSeleccionado.TiempoIluminacion;
        rangoIluminacion = personajeSeleccionado.RangoIluminacion;

        //Pasivas
        iluminarEnemigos = true;
    }
}
