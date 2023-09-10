using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Ataque : MonoBehaviour
{
    public Estadisticas estadisticas;
    [SerializeField] private GameObject prefabAtaque;
    [SerializeField] private Transform spawnAtaque;
    [FormerlySerializedAs("damage")] [SerializeField] private int _damage;

    void Update()
    {
    }
    
    public void Atacar()
    {
        GameObject temp = Instantiate(prefabAtaque, spawnAtaque.position, spawnAtaque.rotation);
    }

    public void  DamageUp(int damage)
    {
        estadisticas.ataque += damage;
    }

}
