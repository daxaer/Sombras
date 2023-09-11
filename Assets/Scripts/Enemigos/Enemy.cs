using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //[SerializeField] private Transform target;
    [SerializeField] private float _vida;
    //[SerializeField] private PoolAlmas _alma;
    //[SerializeField] private GameObject target;

    private SpawnManager spawnManager;

    private void Start()
    {
        spawnManager = FindAnyObjectByType<SpawnManager>(); //encontrar 
    }

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
        print("se apaga");
        gameObject.SetActive(false); //nos apagamos para seguir en el pool
    }

    private void OnDestroy()
    {
        spawnManager.DecreaseEnemyCount(); //disminuir contador
    }
}
