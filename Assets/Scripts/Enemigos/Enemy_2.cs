using Pathfinding;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_2 : Enemies
{
    //[SerializeField] private Transform target;

    //Vida
    [SerializeField] private float distance;
    [SerializeField] private RaycastHit2D rayCast;
    [SerializeField] private GameObject frontObject;

    public void FixedUpdate()
    {
        Vector2 raycastDirection = Vector2.right;

        rayCast = Physics2D.Raycast(frontObject.transform.position, raycastDirection, distance);
        if (rayCast.collider != null)
        {
            Debug.DrawLine(frontObject.transform.position, rayCast.point, Color.red);
        }
        else
        {
            Debug.DrawLine(frontObject.transform.position, rayCast.point, Color.green);
        }
    }

    private void OnEnable()
    {
        animation_Cuerpo.SetBool("Muerto", false);
        animation_Ojo.SetBool("Muerto", false);
    }


    public override void Atacar()
    {
        EstadisticasManager.Instance.vidaActual -= _damage;
        UIManager.Instance.UpdateVida();
        iluminar.SetActive(false);
        animation_Ojo.SetTrigger("Atacar");
        animation_Cuerpo.SetTrigger("Atacar");
        Desactivar();
    }

    enum PatrolEnemy
    {
        //Estados de ataque del enemigo, Embestir, Quieto, Caminar
        Ram, 
        Stay,
        Walk,
    }
}
