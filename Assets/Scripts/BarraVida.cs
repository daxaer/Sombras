using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{

    [SerializeField] private Slider barraVida;
    public Animator barraAnimator;

    // Start is called before the first frame update
    void Start()
    {
        barraVida = GetComponent<Slider>();
        barraAnimator = GetComponent<Animator>();
    }
    

    public void ValorVidaMaxima(float vidaMaxima)
    {
        barraVida.maxValue = vidaMaxima;
    }
    public void ValorVidaActual(float vidaActual)
    {
        barraVida.value = vidaActual;
    }

    public void EstablecerBarraVida(float cantidadVida)
    {
        ValorVidaMaxima(cantidadVida);
        ValorVidaActual(cantidadVida);
    }

}
