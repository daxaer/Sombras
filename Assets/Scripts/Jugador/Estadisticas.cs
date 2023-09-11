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
    public float VelocidadAtaque;
    public float roboDeVida;
    public float iluminarEnemigo;
    public float duracionLamparas;
    public float rangoIluminacion;



    [SerializeField] private ScriptableEstadisticas personajeSeleccionado;

    private void Start()
    {
        vidaMaxima = personajeSeleccionado.VIdaMaxima;
        velocidadPlayer = personajeSeleccionado.VelocidadDeMovimiento;
        vidaActual = personajeSeleccionado.vidaActual;
        ataque = personajeSeleccionado.ATaque;
        rango = personajeSeleccionado.RangoGolpe;
        VelocidadAtaque = personajeSeleccionado.VelocidadDeAtaque;
        roboDeVida = personajeSeleccionado.PorcentajeRoboDeVida;
        iluminarEnemigo = personajeSeleccionado.RangoIluminacion;
        duracionLamparas = personajeSeleccionado.TiempoIluminacion;
        rangoIluminacion = personajeSeleccionado.RangoIluminacion;

    }
}
