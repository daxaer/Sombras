using Pathfinding;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_DosOjos : Enemies
{
    [SerializeField] private SpriteRenderer cuerpo;
    private bool ojoAbierto;
    private bool ataque;
    [SerializeField] private Transform der;
    [SerializeField] private Transform izq;


    private void OnEnable()
    {
        ataque = false;
        animation_Cuerpo.SetBool("Der", true);
        animation_Ojo.SetBool("Der", true);
        animation_Cuerpo.SetBool("Izq", false);
        animation_Ojo.SetBool("Izq", false);
        _vida = (int)Mathf.Floor(AmountDifficult(Timer.Instance.rondaActual, _vidaMin, _vidaMax));
        aiPath.maxSpeed = AmountDifficult(Timer.Instance.rondaActual, _speedMin, _speedMax);
        _damage = (int)Mathf.Floor(AmountDifficult(Timer.Instance.rondaActual, _damageMin, _damageMax));
        cuerpo.sortingLayerName = "Enemigos";
        cuerpo.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        RecibirDaño = true;
    }
    public override void Atacar()
    {
        if(ojoAbierto == true && ataque == false)
        {
            aiPath.maxSpeed = 0;
            ataque = true;
            DesactivarLuz();
            animation_Ojo.SetTrigger("Atacar");
            animation_Cuerpo.SetTrigger("Atacar");
            cuerpo.sortingLayerName = "Default";
            cuerpo.maskInteraction = SpriteMaskInteraction.None;
        }
    }

    private void Setderecha(int der)
    {
        if (der == 1)
        {
            animation_Cuerpo.SetBool("Der", true);
            animation_Ojo.SetBool("Der", true);
        }
        else
        {
            animation_Cuerpo.SetBool("Der", false);
            animation_Ojo.SetBool("Der", false);
        }
    }
    private void Setizquierda(int izq)
    {
        if (izq == 1)
        {
            animation_Cuerpo.SetBool("Izq", true);
            animation_Ojo.SetBool("Izq", true);
        }
        else
        {
            animation_Cuerpo.SetBool("Izq", false);
            animation_Ojo.SetBool("Izq", false);
        }
    }
    private void SetOjo(int ojo)
    {
        if(ojo == 1)
        {
            animation_Cuerpo.SetBool("Ojo", true);
            ojoAbierto = true;
        }
        else
        {
            animation_Cuerpo.SetBool("Ojo", false);
            ojoAbierto = false;
        }
    }

    public void SpawnAtaque(int spawn)
    {
        if(spawn == 1)
        {
            SpawnManager.Instance.SpawnAtaqueOjo(der, _damage);
        }
        else
        {
            SpawnManager.Instance.SpawnAtaqueOjo(izq, _damage);
        }
        Invoke("Recuperando", 1f);
    }
    private void OnDisable()
    {
        CancelInvoke("Recuperando");
    }

    private void Recuperando()
    {
        aiPath.maxSpeed = AmountDifficult(Timer.Instance.rondaActual, _speedMin, _speedMax);
        cuerpo.sortingLayerName = "Enemigos";
        cuerpo.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        animation_Cuerpo.SetBool("Ojo", false);
        ataque = false;
        ojoAbierto = false;
        Debug.Log("caminando");
    }
}
