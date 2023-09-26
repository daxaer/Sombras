using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : MonoBehaviour
{

    //Vida
    [SerializeField] private float _vida;
    [SerializeField] private float _lifeIncrease = 1f;
    [SerializeField] private GameObject iluminar;
    [SerializeField] private GameObject maskara;

    //probabilidad
    [SerializeField] private SpawnManager _spawnManager;

    //Behaviour Enemy
    [SerializeField] private AIPath _enemyAgent;
    [SerializeField] private GameObject _player;

    public float _normalSpeed = 2f;
    public float _fullSpeed = 10f;
    public float _attackDuration = 5f;
    public float _detectionDistance = 5f;
    public float _defaultSpeed = 5f;
    public bool _isAttack = false;

    private void Start()
    {
        _defaultSpeed = _enemyAgent.maxSpeed;
    }

    private void Update()
    {
        if (_isAttack)
        {
            _enemyAgent.transform.position = _enemyAgent.transform.forward * _fullSpeed;
        }
        else
        {
            //_enemyAgent.GetComponent<AIDestinationSetter>().target = _player;
            //_enemyAgent.maxSpeed = _normalSpeed;

            Vector2 _direction = _player.transform.position - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, _detectionDistance);

            Debug.DrawLine(transform.position, hit.point, Color.red);

            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                StartAttack();
            }
        }
    }

    void StartAttack()
    {
        _isAttack = true;
        _enemyAgent.maxSpeed = _fullSpeed;

        StartCoroutine(ResetSpeedAfterDelay());
    }

    private IEnumerator ResetSpeedAfterDelay()
    {
        yield return new WaitForSeconds(_attackDuration);
        _isAttack = false;
        _enemyAgent.maxSpeed = _normalSpeed;
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
    public void Activarluz()
    {
        iluminar.SetActive(true);
        maskara.SetActive(true);
        CancelInvoke("DesactivarLuz");
        Invoke(nameof(DesactivarLuz), 2f);
    }

    public void DesactivarLuz()
    {
        iluminar.SetActive(false);
        maskara.SetActive(false);
    }
}
