using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemySpawn;
    [SerializeField] private bool _stopSpawning;
    [SerializeField] private float _spawnTime;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float spawnY;
    [SerializeField] private float spawnx;
    [SerializeField] private float[] rangoMinimoYMaximo;
    [SerializeField] private float[] rangoProhibido;

    [SerializeField] private Transform target;
    //pool
    Pool _objectPool;

    // Start is called before the first frame update
    public void DetenerSpawn()
    {
        _stopSpawning = true;
    }
    void Start()
    {
        _objectPool = new Pool();
        _objectPool.Inicializar(_enemySpawn, 5);

        InvokeRepeating("SpawnEnemy", _spawnTime, _spawnDelay);
    }

    public void SpawnEnemy()
    {
        Vector3 position = new Vector3(RandomizarNumero(), RandomizarNumero(), 0);
        GameObject go = _objectPool.Spawn(position, transform.rotation);
        go.GetComponent<AIDestinationSetter>().target = target;
        if(_stopSpawning)
        {
            CancelInvoke("SpawnEnemy");
            //timer en 0
        }
    }
    private float RandomizarNumero()
    {
        float numero = Random.Range(rangoMinimoYMaximo[0], rangoMinimoYMaximo[1]);
        if (numero > rangoProhibido[0] && numero < rangoProhibido[1])
        {
            return RandomizarNumero();
        }
        else
        {
            return numero;
        }
    }

    public Transform Target()
    {
        return target;
    }
}