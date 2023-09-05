using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Jugador", menuName = "DatosJuego")]
public class Estadisticas : ScriptableObject
{
    [Header("Jugador")]
    [SerializeField] private string nombreJugador;
    [SerializeField] private int vidaMaxima;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float velocidadDeAtaque;
    [SerializeField] private float porcentajeRoboDeVida;
    [Header("Lamparas")] 
    [SerializeField] private float rangoIluminacion;
    [SerializeField] private float tiempoIluminacion;

    public string NombreJugador { get { return nombreJugador; } }
    public string VIdaMaxima { get { return nombreJugador; } }
    public string VelocidadDeMovimiento { get { return nombreJugador; } }
    public string VelocidadDeAtaque { get { return nombreJugador; } }
    public string PorcentajeRoboDeVida { get { return nombreJugador; } }
    public string RangoIluminacion { get { return nombreJugador; } }
    public string TiempoIluminacion { get { return nombreJugador; } }
}