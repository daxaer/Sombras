using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{

    //instancias pools
    //[SerializeField] private Estadisticas _estadisticas;
    [SerializeField] private GameObject[] _enemySpawn;
    [SerializeField] private GameObject _almaSpawn;

    [SerializeField] private bool _stopSpawning;
    [SerializeField] private float _spawnTime;
    [SerializeField] private float _spawnDelay = 1f; //intervalo entre cada instancia
    [SerializeField] private float spawnY;
    [SerializeField] private float spawnx;
    [SerializeField] private float[] rangoMinimoYMaximo;
    [SerializeField] private float[] rangoProhibido;
    [SerializeField] private GameObject[] _lamp;
    [SerializeField] private float timeLamp;

    [SerializeField] private int maxEnemies = 10; //limite de enemigos
    [SerializeField] private int _startEnemyCount = 1; //Cantidad inicial de enemigos
    [SerializeField] private int _enemiesPerInterval = 1; //Cantidad de enemigos a aumentar por intervalo
    [SerializeField] private float _timeSinceLastSpawn = 0f; //Tiempo transcurrido desde la ultima instancia
    [SerializeField] private int _currentEnemiesCount = 0; //enemigos actuales en pantalla

    //private List<GameObject> enemies = new List<GameObject>();

    [SerializeField] private SpawnManager spawn;
    [SerializeField] private Transform spawnPlayer;
    [HideInInspector] public int _generateRandomEnemy;
    [SerializeField] public Timer timer;

    //pool
    public Pool _poolAlmas;
    public Pool _poolBalas;
    public Enemy _enemy;
    public Pool _PoolEnemy1;
    public Pool _PoolEnemy2;
    public Pool _PoolEnemy3;

    public static SpawnManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
        SpawnearPlayer();
    }

    void Start()
    {
        //Enemigos
        _PoolEnemy1 = new Pool();
        _PoolEnemy1.Inicializar(_enemySpawn[0], 3);
        _PoolEnemy2 = new Pool();
        _PoolEnemy2.Inicializar(_enemySpawn[1], 3);
        _PoolEnemy3 = new Pool();
        _PoolEnemy3.Inicializar(_enemySpawn[2], 3);

        //Almas
        _poolAlmas = new Pool();
        _poolAlmas.Inicializar(_almaSpawn, 10);
        //Balas
        _poolBalas = new Pool();
        _poolBalas.Inicializar(EstadisticasManager.Instance.bala, 0);
        InvokeRepeating("SpawnEnemy", _spawnTime, _spawnDelay);
        StartCoroutine("ActivarLampara");

        for (int i = 0; i < _startEnemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    private void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;

        //verificar si ha pasado tiempo suficiente para el proximo enemigo
        if(_timeSinceLastSpawn >= _spawnDelay )
        {
            _timeSinceLastSpawn = 0;
            //Aumentar el numero de enemigos actuales en pantalla
            for(int i = 0; i < _enemiesPerInterval; i++)
            {
                SpawnEnemy();
            }
        }
    }
    public void DetenerSpawn()
    {
        _stopSpawning = true;
    }

    public void RestarCurrentEnemy()
    {
        _currentEnemiesCount--;
    }

    public void SpawnEnemy()
    {
        Vector3 position = new Vector3(RandomizarNumero(), RandomizarNumero(), 0);
        int countRound = timer.rondaActual;
        if (countRound >= 3)
        {
            countRound = 3;
        }

        int randomEnemy = Random.Range(1, countRound + 1);
        
        
        if (_currentEnemiesCount < maxEnemies)
        {
            switch (randomEnemy)
            {
                case 1:
                    GameObject go = _PoolEnemy1.Spawn(position, transform.rotation);
                    go.GetComponent<AIDestinationSetter>().target = Player.Instance.transform;
                    break;
                case 2:
                    GameObject go1 = _PoolEnemy2.Spawn(position, transform.rotation);
                    go1.GetComponent<AIDestinationSetter>().target = Player.Instance.transform;
                    break;
                case 3:
                    GameObject go2 = _PoolEnemy3.Spawn(position, transform.rotation);
                    go2.GetComponent<AIDestinationSetter>().target = Player.Instance.transform;
                    break;

                default:
                    Debug.Log("No hay enemigo joven");
                    break;
            }
            _currentEnemiesCount++;
            if (_stopSpawning)
            {
                CancelInvoke("SpawnEnemy");
            }
        }
    }


    public void SpawnAlmas(Transform transform)
    {
        GameObject alma = _poolAlmas.Spawn(transform.position, transform.rotation);
    }

    public GameObject SpawnAtaque(Transform transform)
    {
        GameObject bala = _poolBalas.Spawn(transform.position, transform.rotation);
        Debug.Log("bala" + bala);
        return bala;
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

    IEnumerator  ActivarLampara()
    {
        int numero = Random.Range(1, _lamp.Length);
        if (_lamp[numero].GetComponent<Lampara>().Activado == true)
        {
            _lamp[numero].GetComponent<Lampara>().Activado = true;
            //_lamp[numero].GetComponent<Lampara>().RangoLuz(_estadisticas.rangoIluminacion);
            //_lamp[numero].GetComponent<Lampara>().TiempoIluminacion(_estadisticas.duracionLamparas);
        }
        else
        {
            _lamp[numero].GetComponent<Lampara>().Activado = false;
        }
        _lamp[numero].SetActive(true);
        yield return new WaitForSeconds(timeLamp);
    }

    private void SpawnearPlayer()
    {
       Instantiate(GameManager.Instance.PlayerSave(),spawnPlayer);
    }
}