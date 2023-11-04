using Pathfinding;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Enemies
{
    [SerializeField] private CircleCollider2D circulo;
    private void OnEnable()
    {
        circulo.enabled = true;
        animation_Cuerpo.SetBool("Muerto", false);
        animation_Ojo.SetBool("Muerto", false);
        gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Enemigos";
        gameObject.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        GetComponent<AIDestinationSetter>().target = Player.Instance.transform;
        _vida = (int)Mathf.Floor(AmountDifficult(Timer.Instance.rondaActual, _vidaMin, _vidaMax));
        aiPath.maxSpeed = AmountDifficult(Timer.Instance.rondaActual, _speedMin, _speedMax);
        _damage = (int)Mathf.Floor(AmountDifficult(Timer.Instance.rondaActual, _damageMin, _damageMax));
        RecibirDaño = true;
    }

    public override void Atacar()
    {
        MusicManager.Instance.PlayAudioPool(SOUNDTYPE.ENEMY_EXPLOSION, transform);
        animation_Ojo.SetTrigger("Atacar");
        animation_Cuerpo.SetTrigger("Atacar");
        circulo.enabled = false;
        gameObject.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
        gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        aiPath.maxSpeed = 0;
        DesactivarLuz();
    }

    public void SpawnAtaque()
    {
        SpawnManager.Instance.SpawnExplosion(transform,_damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Atacar();
        }
    }
}
