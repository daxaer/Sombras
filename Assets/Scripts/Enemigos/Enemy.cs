using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //[SerializeField] private Transform target;

    //Vida
    [SerializeField] private float _vida;
    [SerializeField] private float _lifeIncrease = 1f;
    [SerializeField] private GameObject iluminar;
    [SerializeField] private Animator animation_Ojo;
    [SerializeField] private Animator animation_Cuerpo;


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
    private void OnEnable()
    {
        animation_Cuerpo.SetBool("Muerto", false);
        animation_Ojo.SetBool("Muerto", false);

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
        //iluminar.SetActive(false);
        //animation_Ojo.SetTrigger("Atacar");
        //animation_Cuerpo.SetTrigger("Atacar");
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
}
