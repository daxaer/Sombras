using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Projectil : MonoBehaviour
{
    //[SerializeField] private Estadisticas estadisticas;
    [SerializeField] private float velocidad;
    
    private void OnEnable()
    {
        if(EstadisticasManager.Instance.ataqueMele)
        {
            Invoke("Destruir", 0.8f);
        }
        else
        {
            Invoke("Destruir", 0.3f);
        }
    }

    private void Update()
    {
        Debug.Log("velocidad" +  velocidad);
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(EstadisticasManager.Instance.ataque);
            if (EstadisticasManager.Instance.iluminarEnemigos == true)
            {
                enemy.Activarluz();
            }
            roboVida();
        }
    }
    public void roboVida()
    {
        float robo = UnityEngine.Random.Range(0, 101);
        if (robo <= EstadisticasManager.Instance.roboDeVida)
        {
            Player.Instance.RecuperarVIda(1);
        }
    }
    public void Destruir()
    {
        gameObject.SetActive(false);
    }

    public void AumentoRango()
    {
        gameObject.transform.localScale = new Vector3(EstadisticasManager.Instance.rango, EstadisticasManager.Instance.rango, 1);
    }

}
