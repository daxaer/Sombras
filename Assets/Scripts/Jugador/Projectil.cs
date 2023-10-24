using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Projectil : MonoBehaviour
{
    //[SerializeField] private Estadisticas estadisticas;
    [SerializeField] private float velocidad;
<<<<<<< HEAD
<<<<<<< HEAD
    [SerializeField] bool hit;
    
    private void OnEnable()
    {
        hit = false;
        if(EstadisticasManager.Instance.ataqueMele)
        {
            Invoke("Destruir", 0.8f);
        }
        else
        {
            Invoke("Destruir", 0.2f);
        }
=======
    [SerializeField] private SpawnManager _spawnManager;
    
    private void OnEnable()
    {
        Invoke("Destruir", 0.3f);
>>>>>>> parent of 7372f44 (projectil y rejugar)
=======
    [SerializeField] private SpawnManager _spawnManager;
    
    private void OnEnable()
    {
        Invoke("Destruir", 0.3f);
>>>>>>> parent of 7372f44 (projectil y rejugar)
    }

    private void Update()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemies enemy = other.gameObject.GetComponent<Enemies>();
            enemy.TakeDamage(EstadisticasManager.Instance.ataque);
            if (EstadisticasManager.Instance.iluminarEnemigos == true)
            {
                enemy.Activarluz();
            }
            roboVida();
            if (!EstadisticasManager.Instance.ataqueMele)
            {
                Destruir();
                MusicManager.Instance.PlayAudioPool(SOUNDTYPE.HIT_ENEMY_RANGE, other.transform);
            }
            else
            {
                if(!hit)
                {
                    MusicManager.Instance.PlayAudioPool(SOUNDTYPE.HIT_ENEMY_MELE, other.transform);
                }
            }
        }
        else if(other.CompareTag("Pared"))
        {
            if (!EstadisticasManager.Instance.ataqueMele)
            {
                Destruir();
                MusicManager.Instance.PlayAudioPool(SOUNDTYPE.HIT_PARED, other.transform);
            }
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
