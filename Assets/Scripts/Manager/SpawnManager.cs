using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    //Save dates
    [SerializeField] private GameObject player;
    [SerializeField] private bool gameSave;

    //instancias pools
    //[SerializeField] private Estadisticas _estadisticas;
    [SerializeField] private GameObject[] _enemySpawn;
    [SerializeField] private GameObject marca;
    [SerializeField] private GameObject hit;
    [SerializeField] private GameObject _almaSpawn;
    [SerializeField] private GameObject[] _Ataques;
    [SerializeField] private bool _stopSpawning;
    [SerializeField] private float _spawnTime;
    [SerializeField] private float _spawnDelay = 1f; //intervalo entre cada instancia
    [SerializeField] private float spawnY;
    [SerializeField] private float spawnx;
    [SerializeField] private float[] rangoMinimoYMaximo;
    [SerializeField] private GameObject[] _lamp;
    [SerializeField] private float prenderLampara;
    private int lamparaActual;

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
    public Pool _marca;
    public Pool _hit;
    public Pool _poolAlmas;
    public Pool _poolBalas;
    public Enemy _enemy;
    public Pool _PoolEnemy1;
    public Pool _PoolEnemy2;
    public Pool _PoolEnemy3;
    public Pool _PoolAtaqueExplosion;
    public Pool _PoolAtaque2Ojos;
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
        //Fx
        _marca = new Pool();
        _marca.Inicializar(marca, 3);
        _hit = new Pool();
        _hit.Inicializar(hit, 3);
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
        //Ataques Enemigos
        _PoolAtaqueExplosion = new Pool();
        _PoolAtaqueExplosion.Inicializar(_Ataques[0], 0);

        _PoolAtaque2Ojos = new Pool();
        _PoolAtaque2Ojos.Inicializar(_Ataques[1], 0);

        for (int i = 0; i < _startEnemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    private void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;

        //verificar si ha pasado tiempo suficiente para el proximo enemigo
        if(_timeSinceLastSpawn >= _spawnDelay - (Timer.Instance.rondaActual * 0.01) )
        {
            Debug.Log(_spawnDelay - (Timer.Instance.rondaActual * 0.05) + "operacion");
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
        if (countRound >= 4)
        {
            countRound = 4;
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
        {
            return numero;
        }
    }

    IEnumerator  ActivarLampara()
    {
        lamparaActual = Random.Range(1, _lamp.Length);
        _lamp[lamparaActual].SetActive(true);
        _lamp[lamparaActual].GetComponent<Animator>().SetTrigger("Prender");
        yield return new WaitForSeconds(prenderLampara);
        StartCoroutine("ActivarLampara");
    }

    public void SpawnExplosion(Transform transform, int damage)
    {
        GameObject explosion = _PoolAtaqueExplosion.Spawn(transform.position, transform.rotation);
        explosion.GetComponent<AtaquesEnemigos>().damage = damage;
    }
    public void SpawnAtaqueOjo(Transform transform, int damage)
    {
        GameObject ataqueOjo = _PoolAtaque2Ojos.Spawn(transform.position, transform.rotation);
        ataqueOjo.GetComponent<AtaquesEnemigos>().damage = damage;
    }
    private void SpawnearPlayer()
    {
        Instantiate(GameManager.Instance.PlayerSave(), spawnPlayer);
    }
    IEnumerator SpawnEnemyes()
    {
        yield return new WaitForSeconds(1f);
    }
    public void SpawnHit(Transform transform)
    {
        GameObject explosion = _hit.Spawn(transform.position, transform.rotation);
    }

}