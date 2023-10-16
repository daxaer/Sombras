using Pathfinding;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_2 : MonoBehaviour
{
    //[SerializeField] private Transform target;

    //Vida
    [SerializeField] private float _vida;
    [SerializeField] private float _lifeIncrease = 1f;
    [SerializeField] private GameObject iluminar;
    [SerializeField] private Animator animation_Ojo;
    [SerializeField] private Animator animation_Cuerpo;
    [SerializeField] private int damage;
    [SerializeField] private float distance;
    [SerializeField] private RaycastHit2D rayCast;
    [SerializeField] private GameObject frontObject;
    [SerializeField] private AIPath aiPath;

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

    //probabilidad
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
        SpawnManager.Instance.RestarCurrentEnemy();
        SpawnManager.Instance.SpawnAlmas(gameObject.transform);
        gameObject.SetActive(false); //nos apagamos para seguir en el pool
    }

    public void Atacar()
    {
        EstadisticasManager.Instance.vidaActual -= damage;
        UIManager.Instance.UpdateVida();
        iluminar.SetActive(false);
        animation_Ojo.SetTrigger("Atacar");
        animation_Cuerpo.SetTrigger("Atacar");
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

    enum PatrolEnemy
    {
        //Estados de ataque del enemigo, Embestir, Quieto, Caminar
        Ram, 
        Stay,
        Walk,
    }
}
