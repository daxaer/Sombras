using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class SpawnAlmas : MonoBehaviour
{
    private Action<SpawnAlmas> desactivarAlma;
    private int tipoAlma;

    public void OnEnable()
    {
        float probabilidad = Random.Range(1, 100);
        Debug.Log("probabilidad");
        if (probabilidad >= 90)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            tipoAlma = 1;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            tipoAlma = 2;
        }
    }

    public int TipoAlma()
    {
        return tipoAlma;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            desactivarAlma(this);
        }
    }

    public void DesactivarAlma(Action<SpawnAlmas> desactivarParametro)
    {
        desactivarAlma = desactivarParametro;
    }
}
