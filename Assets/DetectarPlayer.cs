using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectarPlayer : MonoBehaviour
{
    [SerializeField] private Enemies enemigo;
    private Vector3 distancia;
    private bool puedoAtacar;
    void Update()
    {
        distancia = transform.position - Player.Instance.transform.position;
        if (distancia.magnitude <= 3 && puedoAtacar)
        {
            enemigo.Atacar();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            puedoAtacar = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            puedoAtacar = false;
        }
    }
}
