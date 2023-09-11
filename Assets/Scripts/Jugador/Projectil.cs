using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Projectil : MonoBehaviour
{
    private float _damage = 1;
    [SerializeField] private Estadisticas estadisticas;
    [SerializeField] private MovimientoPersonaje movimientoPersonaje;

    public Estadisticas EstadisticasPersonaje { get { return estadisticas; } set { estadisticas = value; } }
    public MovimientoPersonaje Movimiento { get { return movimientoPersonaje; } set { movimientoPersonaje = value; } }
    private void Start()
    {
        AumentoRango();
        _damage = estadisticas.ataque;
        Destroy(gameObject,0.3f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("choque");
            other.GetComponent<Enemy>().TakeDamage(_damage);
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
        Destroy(gameObject);    
    }

    public void AumentoRango()
    {
        gameObject.transform.localScale = new Vector3(estadisticas.rango, estadisticas.rango, 1);
    }
}
