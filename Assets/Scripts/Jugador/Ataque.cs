using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Ataque : MonoBehaviour
{
    [SerializeField] private GameObject prefabAtaque;
    [SerializeField] private Transform spawnAtaque;
    [FormerlySerializedAs("damage")] [SerializeField] private int _damage;
    public float damage = 1;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Atacar();
        }
    }
    
    private void Atacar()
    {
        GameObject temp = Instantiate(prefabAtaque, spawnAtaque.position, spawnAtaque.rotation);
    }

    public void  DamageUp(int damage)
    {
        _damage += damage;
    }

}
