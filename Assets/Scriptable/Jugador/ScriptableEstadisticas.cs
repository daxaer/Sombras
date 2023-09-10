using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Jugador", menuName = "DatosJuego")]
public class ScriptableEstadisticas : ScriptableObject
{
    [Header("Jugador")]
    [SerializeField] private string nombreJugador;
    [SerializeField] private int vidaMaxima;
    [SerializeField] private int Ataque;
    public int vidaActual;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float velocidadDeAtaque;
    [SerializeField] private float porcentajeRoboDeVida;
    [SerializeField] private float rangoGolpe;
    [Header("Lamparas")] 
    [SerializeField] private float rangoIluminacion;
    [SerializeField] private float tiempoIluminacion;

    public string NombreJugador { get { return nombreJugador; } }
    public int VIdaMaxima { get { return vidaMaxima; } }
    public int ATaque { get { return Ataque; } }
    public float VelocidadDeMovimiento { get { return velocidadMovimiento; } }
    public float VelocidadDeAtaque { get { return velocidadDeAtaque; } }
    public float PorcentajeRoboDeVida { get { return porcentajeRoboDeVida; } }
    public float RangoGolpe { get { return rangoGolpe; } }
    public float RangoIluminacion { get { return rangoIluminacion; } }
    public float TiempoIluminacion { get { return tiempoIluminacion; } }
}