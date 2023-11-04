using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deteccion : MonoBehaviour
{
    [SerializeField] private Enemies enemigo;
    private Vector3 distancia;
    float angulo;
    public float viendo = 30f;

    void Update()
    {
        distancia = Player.Instance.transform.position - transform.position;

        if (distancia.magnitude < 3)
        {
            enemigo.Cargando();
        }
    }
}
