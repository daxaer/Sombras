using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Jugador", menuName = "DatosJuego")]
public class ScriptableEstadisticas : ScriptableObject
{
    [Header("Jugador")]
    [SerializeField] private string[] nombreJugador;
    [SerializeField] private float vidaMaxima;
    [SerializeField] private float ataque;
    [SerializeField] private bool iluminar;
    public float vidaActual;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float velocidadDeAtaque;
    [SerializeField] private float porcentajeRoboDeVida;
    [SerializeField] private float projectileSize;
    [SerializeField] private float velocidadBala;
    [SerializeField] private bool ataqueMele;
    [Header("Lamparas")] 
    [SerializeField] private float rangoIluminacion;
    [SerializeField] private float tiempoIluminacion;
    [SerializeField] private GameObject bala;

    public string NombreJugador(int idioma)
    {
        if (idioma >= 0 && idioma < nombreJugador.Length)
        {
            return nombreJugador[idioma];
        }
        else
        {
            return "No existe el idioma";
        }
    }
    public float VidaMaxima { get { return vidaMaxima; } }
    public float Ataque { get { return ataque; } }
    public bool Iluminar { get { return iluminar; } }
    public float VelocidadDeMovimiento { get { return velocidadMovimiento; } }
    public float VelocidadDeAtaque { get { return velocidadDeAtaque; } }
    public float PorcentajeRoboDeVida { get { return porcentajeRoboDeVida; } }
    public float ProjectileSize { get { return projectileSize; } }
    public float VelocidadBala { get { return velocidadBala; } }

    public bool AtaqueMele { get { return ataqueMele; } }
    public float RangoIluminacion { get { return rangoIluminacion; } }
    public float TiempoIluminacion { get { return tiempoIluminacion; } }
    public GameObject Bala { get { return bala; } set { bala = value; } }
}