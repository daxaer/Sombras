using Pathfinding;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Enemies
{
    private void OnEnable()
    {
        Debug.Log("en enemigo1");
        animation_Cuerpo.SetBool("Muerto", false);
        animation_Ojo.SetBool("Muerto", false);
    }

    public override void Atacar()
    {
      
        iluminar.SetActive(false);
        animation_Ojo.SetTrigger("Atacar");
        animation_Cuerpo.SetTrigger("Atacar");
        Desactivar();
    }

    public void SpawnAtaque()
    {
        SpawnManager.Instance.SpawnExplosion(transform);
    }
}
