using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deteccion : MonoBehaviour
{
    [SerializeField] private Enemies enemigo;
    private Vector3 distancia;
    private bool puedoAtacar;

    // Update is called once per frame
    void Update()
    {
        distancia = transform.position - Player.Instance.transform.position;
        if(distancia.magnitude > 5 && puedoAtacar)
        {
            enemigo.Cargando();
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
