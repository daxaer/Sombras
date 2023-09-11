using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lampara : MonoBehaviour
{
    [SerializeField] private float tiempoParpadeo;
    [SerializeField] private float tiempoSinLuz;
    [SerializeField] private float tiempoIluminacion;
    [SerializeField] private float ReiniciandoLuz;
    [SerializeField] private bool luzPrendida;
    [SerializeField] private SpriteRenderer luz;
    [SerializeField] private bool activado;
    [SerializeField] private float rangoLuz;

    public bool Activado { get { return activado; } set { activado = value;  } }
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
        yield return new WaitForSeconds(tiempoIluminacion);
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
    public void RangoLuz(float _rangoLuz)
    {
        rangoLuz = _rangoLuz;
        SetRango();
    }

    public void TiempoIluminacion(float _tiempoIluminacion)
    {
        tiempoIluminacion = _tiempoIluminacion;
    }
    public void SetRango()
    {
        gameObject.transform.localScale = new Vector3(rangoLuz, rangoLuz, 1f);
    }
}
