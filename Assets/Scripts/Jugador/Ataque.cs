using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Ataque : MonoBehaviour
{
    public Estadisticas estadisticas;
    public AudioSource sonidoAtaque;
    [SerializeField] private GameObject prefabAtaque;
    [SerializeField] private Transform spawnAtaque;
    [FormerlySerializedAs("damage")] [SerializeField] private int _damage;


    [SerializeField] private float _attackDelay = 5f; //delay
    public KeyCode attackKey = KeyCode.Space; //tecla
    [SerializeField] private bool _canAttack = true; //se puede atacar?
    [SerializeField] private float _attackTimer = 0f; //contador entre ataques
    [SerializeField] private float _attackSpeedMultiplier = 1f; // multiplicador de velocidad de ataque

    void Update()
    {
        _attackTimer = Time.time; //contador

        //verificar si se puede atacar y mantiene presionada la tecla
        if( _canAttack && Input.GetKey(attackKey))
        {
            Atacar();
            _attackTimer = 0;
            _canAttack = false;

            StartCoroutine(EnableAttackAfterDelay());
        }
    }
    
    public void Atacar()
    {
        sonidoAtaque.Play();
        GameObject temp = Instantiate(prefabAtaque, spawnAtaque.position, spawnAtaque.rotation);
        float modifiedAttackDelay = _attackDelay / _attackSpeedMultiplier;
        _attackTimer = Mathf.Clamp(_attackTimer, 0f, modifiedAttackDelay);
    }

    private IEnumerator EnableAttackAfterDelay()
    {
        yield return new WaitForSeconds(_attackDelay);

        _canAttack = true;
    }

    private void IncreaseAttackSpeed(float _multiplier)
    {
        _attackSpeedMultiplier *= _multiplier;
    }

    private void RoboDeVIda()
    {

    }

    public void  DamageUp(int damage)
    {
        estadisticas.ataque += damage;
    }

}
