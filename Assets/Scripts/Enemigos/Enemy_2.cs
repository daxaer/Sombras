using Pathfinding;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Enemy_2 : Enemies
{
    //[SerializeField] private Transform target;
    [SerializeField] GameObject PuntoFinal;
    [SerializeField] bool puedoAtacar;
    [SerializeField] CapsuleCollider2D cebo;
    [SerializeField] BoxCollider2D box;

    private void OnEnable()
    {
        DesactivarLuz();
        RecibirDaño = true;
        puedoAtacar = true;
        animation_Cuerpo.SetTrigger("caminando");
        animation_Ojo.SetTrigger("caminando");
        gameObject.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Enemigos";
    }
    private void OnDisable()
    {
        CancelInvoke("Cargando");
        CancelInvoke("Carga");
        CancelInvoke("TerminarCarga");
        CancelInvoke("RecuperandoCarga");
    }

    public  override void Cargando()
    {
        if(puedoAtacar == true)
        {
            gameObject.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
            box.enabled = false;
            GetComponent<AIDestinationSetter>().target = this.PuntoFinal.transform;
            aiPath.maxSpeed = 0;
            animation_Cuerpo.SetTrigger("cargando");
            animation_Ojo.SetTrigger("cargando");
            Invoke("Atacar", 1);
            puedoAtacar = false;
        }
    }
    public override void Atacar()
    {
        aiPath.maxSpeed = AmountDifficult(Timer.Instance.rondaActual, _speedMin, _speedMax) * 3;
        UIManager.Instance.UpdateVida();
        animation_Ojo.SetTrigger("atacando");
        animation_Cuerpo.SetTrigger("atacando");
        Invoke("TerminarCarga", 3f);
    }
   
    public void TerminarCarga()
    {
        animation_Ojo.SetTrigger("recuperando");
        animation_Cuerpo.SetTrigger("recuperando");
        aiPath.maxSpeed = 0;
        Invoke("RecuperarDestino", 2);
    }
    public void RecuperarDestino()
    {
        animation_Ojo.SetTrigger("caminando");
        animation_Cuerpo.SetTrigger("caminando");
        animation_Brillo.SetTrigger("caminando");
        aiPath.maxSpeed = AmountDifficult(Timer.Instance.rondaActual, _speedMin, _speedMax);
        GetComponent<AIDestinationSetter>().target = Player.Instance.transform;
        puedoAtacar = true;
        cebo.enabled = true;
        box.enabled = true;
        gameObject.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Enemigos";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !puedoAtacar)
        {
            Player.Instance.TakeDamage(_damage);
        }
    }
}