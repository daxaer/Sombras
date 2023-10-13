using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;


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
    [SerializeField] private Transform target;
    [SerializeField] private Transform spawnPlayer;
    [SerializeField] private GameObject jugador;


    //pool
    public Pool _objectPool;
    public Pool _poolAlmas;
    public Pool _poolBalas;
    public Enemy _enemy;
   
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
        //jugador = GameManager.Instance.Player().Player;
        //Enemigos
        _objectPool = new Pool();
        _objectPool.Inicializar(_enemySpawn[Random.Range(0, _enemySpawn.Length)], 5);
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

        if (_currentEnemiesCount < maxEnemies)
        {
            GameObject go = _objectPool.Spawn(position, transform.rotation);
            go.GetComponent<AIDestinationSetter>().target = Player.Instance.transform;
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

    public Transform Target()
    {
        return target;
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