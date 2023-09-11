using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemySpawn;
    [SerializeField] private bool _stopSpawning;
    [SerializeField] private float _spawnTime;
    [SerializeField] private float _spawnDelay = 1f; //intervalo entre cada instancia
    [SerializeField] private float spawnY;
    [SerializeField] private float spawnx;
    [SerializeField] private float[] rangoMinimoYMaximo;
    [SerializeField] private float[] rangoProhibido;

    [SerializeField] private int maxEnemies = 10; //limite de enemigos
    [SerializeField] private int currentEnemies = 0; //contador de enemigos
    [SerializeField] private int _startEnemyCount = 1; //Cantidad inicial de enemigos
    [SerializeField] private int _enemiesPerInterval = 1; //Cantidad de enemigos a aumentar por intervalo
    [SerializeField] private float _timeSinceLastSpawn = 0f; //Tiempo transcurrido desde la ultima instancia
    [SerializeField] private int _currentEnemiesCount = 0; //enemigos actuales en pantalla

    private List<GameObject> enemies = new List<GameObject>();


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

        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject enemyObject in enemyObjects) 
        {
            enemies.Add(enemyObject);
        }

        for (int i = 0; i < _startEnemyCount; i++)
        {
            SpawnEnemy();
            _currentEnemiesCount++;
        }

        //InvokeRepeating("SpawnEnemy", _spawnTime, _spawnDelay);
    }

    private void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;

        //verificar si ha pasado tiempo suficiente para el proximo enemigo
        if(_timeSinceLastSpawn >= _spawnDelay )
        {
            _timeSinceLastSpawn = 0;


            //Aumentar el numero de enemigos actuales en pantalla
            _currentEnemiesCount += _enemiesPerInterval;


            for(int i = 0; i < _enemiesPerInterval; i++)
            {
                SpawnEnemy();
            }
        }
    }

    public void DestroyAllEnemies()
    {
        foreach(GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        enemies.Clear();
    }

    public void CurrentEnemy()
    {
        _currentEnemiesCount--;
    }
    public void SpawnEnemy()
    {
        Vector3 position = new Vector3(RandomizarNumero(), RandomizarNumero(), 0);

        if (currentEnemies < maxEnemies)
        {
            GameObject go = _objectPool.Spawn(position, transform.rotation);
            go.GetComponent<AIDestinationSetter>().target = target;
            currentEnemies++;
            if (_stopSpawning)
            {
                CancelInvoke("SpawnEnemy");
                //timer en 0
            
                
            }
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