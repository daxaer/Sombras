using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Projectil : MonoBehaviour
{
    [SerializeField] private Estadisticas estadisticas;
    [SerializeField] private MovimientoPersonaje movimientoPersonaje;
    [SerializeField] private float velocidad;
    [SerializeField] private SpawnManager _spawnManager;

    public Estadisticas EstadisticasPersonaje { get { return estadisticas; } set { estadisticas = value; } }
    public MovimientoPersonaje Movimiento { get { return movimientoPersonaje; } set { movimientoPersonaje = value; } }
    
    private void OnEnable()
    {
        Invoke("Destruir", 0.3f);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(estadisticas.ataque);
            if (estadisticas.iluminarEnemigos == true)
            {
                enemy.Activarluz();
            }
            roboVida();
        }
    }
    public void roboVida()
    {
        float robo = UnityEngine.Random.Range(0, 101);
        if (robo <= estadisticas.roboDeVida)
        {
            movimientoPersonaje.RecuperarVIda(1);
        }
    }
    public void Destruir()
    {
        gameObject.SetActive(false);
    }

    public void AumentoRango()
    {
        gameObject.transform.localScale = new Vector3(estadisticas.rango, estadisticas.rango, 1);
    }

}
