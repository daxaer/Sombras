using Pathfinding;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_2 : Enemies
{
    //[SerializeField] private Transform target;
    [SerializeField] float velCarga;
    [SerializeField] GameObject PuntoFinal;
    [SerializeField] bool puedoAtacar;
    [SerializeField] CapsuleCollider2D cebo;

    private void OnEnable()
    {
        puedoAtacar = true;
        animation_Cuerpo.SetBool("Muerto", false);
        animation_Ojo.SetBool("Muerto", false);
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
            puedoAtacar = false;
            GetComponent<AIDestinationSetter>().target = this.PuntoFinal.transform;
            Invoke("Carga", 1);
            aiPath.maxSpeed = 0;
        }
    }

    public override void Atacar()
    {
       EstadisticasManager.Instance.vidaActual -= _damage;
        UIManager.Instance.UpdateVida();
        DesactivarLuz();
        animation_Ojo.SetTrigger("Atacar");
        animation_Cuerpo.SetTrigger("Atacar");
    }

    public void Carga()
    {
        aiPath.maxSpeed = AmountDifficult(Timer.Instance.rondaActual, _speedMin, _speedMax) * 4;
        Invoke("TerminarCarga", 2.5f);
    }
   
    public void TerminarCarga()
    {
        aiPath.maxSpeed = 0;
        GetComponent<AIDestinationSetter>().target = Player.Instance.transform;
        Invoke("RecuperarDestino", 2);
    }
    public void RecuperarDestino()
    {
        aiPath.maxSpeed = AmountDifficult(Timer.Instance.rondaActual, _speedMin, _speedMax);
        puedoAtacar = true;
        cebo.enabled = true;
    }
}