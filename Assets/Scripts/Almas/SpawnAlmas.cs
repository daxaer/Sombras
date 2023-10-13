using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class SpawnAlmas : MonoBehaviour
{
    private int tipoAlma;

    public void OnEnable()
    {
        float probabilidad = Random.Range(1, 100);
        if (probabilidad >= 90)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            tipoAlma = 1;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
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
            gameObject.SetActive(false);
        }
    } 
}
