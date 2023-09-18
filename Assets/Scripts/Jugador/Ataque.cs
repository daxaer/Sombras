using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Ataque : MonoBehaviour
{
    public Estadisticas estadisticas;
    public AudioSource sonidoAtaque;
    [SerializeField] private GameObject prefabAtaque;
    [SerializeField] private Transform spawnAtaque;
    [SerializeField] private SpawnManager _spawnManager;

    public KeyCode attackKey = KeyCode.Space; //tecla
    [SerializeField] private bool _canAttack = true; //se puede atacar?
    [SerializeField] private MovimientoPersonaje movimientoPersonaje;
    
    public void Atacar()
    {
        if(_canAttack)
        {
            StartCoroutine(SpeedAtack());
            _canAttack = false;
            sonidoAtaque.Play();
            GameObject temp = _spawnManager.SpawnAtaque(spawnAtaque);
            Projectil proj = temp.GetComponent<Projectil>();
            proj.EstadisticasPersonaje = estadisticas;
            proj.Movimiento = movimientoPersonaje;
        }
    }

    private IEnumerator SpeedAtack()
    {
        yield return new WaitForSeconds(estadisticas.VelocidadeAtaque);
        _canAttack = true;
    }
}
