using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lampara : MonoBehaviour
{
    [SerializeField] private float tiempoParpadeo;
    [SerializeField] private float tiempoSinLuz;
    [SerializeField] private float tiempoLuzPrendida;
    [SerializeField] private float ReiniciandoLuz;
    [SerializeField] private bool luzPrendida;
    [SerializeField] private SpriteRenderer luz;
    void Start()
    {
        StartCoroutine("parpaderar");
    }

    IEnumerator parpaderar()
    {
        luz.enabled = false;
        yield return new WaitForSeconds(tiempoSinLuz);
        luz.enabled = true;
        yield return new WaitForSeconds(tiempoParpadeo);
        luz.enabled = false;
        yield return new WaitForSeconds(tiempoSinLuz);
        luz.enabled = true;
        yield return new WaitForSeconds(tiempoParpadeo);
        luz.enabled = false;
        yield return new WaitForSeconds(tiempoSinLuz);
        luz.enabled = true;
        yield return new WaitForSeconds(tiempoLuzPrendida);
        if (luzPrendida)
        {
            StartCoroutine("parpaderar");
        }
        else
        {
            luz.enabled = false;
            StartCoroutine("ApagarLuz");
        }
    }

    IEnumerator ApagarLuz()
    {
        yield return new WaitForSeconds(ReiniciandoLuz);
        StartCoroutine("parpaderar");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && luzPrendida)
        {
            luzPrendida = false;
        }
    }

    private void OntrigerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            luzPrendida = true;
        }
    }
}
