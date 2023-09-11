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

    //probabilidad
    [SerializeField] private float _lifeDropChance = 0.3f;
    [SerializeField] private GameObject _lifePrefab;
    

    private SpawnManager spawnManager;



    private void Start()
    {
        spawnManager = FindAnyObjectByType<SpawnManager>(); //encontrar 
    }

    private void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        _vida -= damage;

        if (_vida <= 0)
        {

            spawnManager.CurrentEnemy();
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
        print("se apaga");
        gameObject.SetActive(false); //nos apagamos para seguir en el pool
    }
}
