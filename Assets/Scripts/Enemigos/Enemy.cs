using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //[SerializeField] private Transform target;

    //Vida
    [SerializeField] private float _vida;
    [SerializeField] private float _lifeIncrease = 1f;


    //[SerializeField] private PoolAlmas _alma;
    //[SerializeField] private GameObject target;

    //probabilidad
    [SerializeField] private float _lifeDropChance = 0.3f;
    [SerializeField] private GameObject _lifePrefab;
    
    [SerializeField] private SpawnManager _spawnManager;

    public void TakeDamage(float damage)
    {
        _vida -= damage;

        if (_vida <= 0)
        {
            
            //_alma.ActivarAlma();
            Invoke(nameof(Desactivar), 0f);

            float randomValue = UnityEngine.Random.Range(0f, 1f); //numero aleatorio entre 0 y 1

            //si numero aleatorio menor o igual a probabilidad de soltar vida
            if(randomValue <= _lifeDropChance)
            {
                Instantiate(_lifePrefab, transform.position, Quaternion.identity);
            }

        }
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Desactivar));
    }
    public void Desactivar() // esto sera mi nuevo "Destruir"
    {
        _spawnManager.RestarCurrentEnemy();
        _spawnManager.SpawnAlmas(gameObject.transform);
        gameObject.SetActive(false); //nos apagamos para seguir en el pool
    }

    public void SetSpawn(SpawnManager spawn)
    {
        _spawnManager = spawn;
    }

    public void Atacar()
    {
        gameObject.SetActive(false);
    }
    public void IncreaseLife()
    {
        //Aumentar vida del enemigo
        _vida += _lifeIncrease;
    }
}
