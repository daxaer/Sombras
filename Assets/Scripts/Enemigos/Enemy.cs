using Pathfinding;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //[SerializeField] private Transform target;

    //Vida
    [SerializeField] private float _lifeIncrease = 1f;
    [SerializeField] private GameObject iluminar;
    [SerializeField] private Animator animation_Ojo;
    [SerializeField] private Animator animation_Cuerpo;
    [SerializeField] private float _vida;
    [SerializeField] private int _damage;
    [SerializeField] private float _vidaMin;
    [SerializeField] private float _vidaMax;
    [SerializeField] private float _speedMin;
    [SerializeField] private float _speedMax;
    [SerializeField] private float _damageMax;
    [SerializeField] private float _damageMin;

    [SerializeField] private AIPath aiPath;


    private void Update()
    {
        if (!Timer.Instance._stoptimer)
        {
            DeactivateEnemies();
        }
    }

    //probabilidad
    public void TakeDamage(float damage)
    {
        _vida -= damage;

        if (_vida <= 0)
        {
            //_alma.ActivarAlma();
            Invoke(nameof(Desactivar), 0f);
        }
    }

    private void OnEnable()
    {
        animation_Cuerpo.SetBool("Muerto", false);
        animation_Ojo.SetBool("Muerto", false);

        _vida = (int)Mathf.Floor(AmountDifficult(Timer.Instance.rondaActual, _vidaMin, _vidaMax));
        aiPath.maxSpeed = AmountDifficult(Timer.Instance.rondaActual, _speedMin, _speedMax);
        _damage = (int)Mathf.Floor(AmountDifficult(Timer.Instance.rondaActual, _damageMin, _damageMax));
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Desactivar));
    }
    public void Desactivar() // esto sera mi nuevo "Destruir"
    {
        SpawnManager.Instance.RestarCurrentEnemy();
        SpawnManager.Instance.SpawnAlmas(gameObject.transform);
        gameObject.SetActive(false); //nos apagamos para seguir en el pool
    }

    public void DeactivateEnemies()
    {
        SpawnManager.Instance.RestarCurrentEnemy();
        gameObject.SetActive(false); //nos apagamos para seguir en el pool
    }

    public void Atacar()
    {
        EstadisticasManager.Instance.vidaActual -= _damage;
        UIManager.Instance.UpdateVida();
        iluminar.SetActive(false);
        animation_Ojo.SetTrigger("Atacar");
        animation_Cuerpo.SetTrigger("Atacar");
        Desactivar();
    }

    public void IncreaseLife()
    {
        //Aumentar vida del enemigo
        _vida += _lifeIncrease;
    }

    public void Activarluz()
    {
        iluminar.SetActive(true);
        CancelInvoke("DesactivarLuz");
        Invoke(nameof(DesactivarLuz), 2f);
    }
    
    public void DesactivarLuz()
    {
        iluminar.SetActive(false);
    }

    public float AmountDifficult(int _round, float _estadisticMin, float _estadisticMax)
    {
        int roundMax = 15;
        float estadistic = _estadisticMin + (_estadisticMax - _estadisticMin) * Mathf.Pow((_round - 1) / (roundMax - 1), 3);
        return estadistic;
    }
}
