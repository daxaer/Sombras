using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //[SerializeField] private Transform target;
    [SerializeField] private float _vida;
    //[SerializeField] private PoolAlmas _alma;
    //[SerializeField] private GameObject target;

    //probabilidad
    [SerializeField] private SpawnManager _spawnManager;

    public void TakeDamage(float damage)
    {
        _vida -= damage;

        if (_vida <= 0)
        {
            //_alma.ActivarAlma();
            Invoke(nameof(Desactivar), 0f);
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

}
