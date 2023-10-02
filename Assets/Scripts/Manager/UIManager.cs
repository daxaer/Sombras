using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider barraVida;
    [SerializeField] private Animator barraAnimator;
    [SerializeField] private Image MaskBarra;
    [SerializeField] private float velocidadBarra;

    private float valorBarraFinal;

    public static UIManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
        MaskBarra.fillAmount = 1f;
        valorBarraFinal = MaskBarra.fillAmount;
    }

    private void Update()
    {
        if (MaskBarra.fillAmount != valorBarraFinal)
        {
            MaskBarra.fillAmount = Mathf.MoveTowards(MaskBarra.fillAmount, valorBarraFinal, Time.deltaTime * velocidadBarra);
        }
    }

    public void ValorBarraPorcentual(float vidaPorcentaje)
    {
        valorBarraFinal = vidaPorcentaje;
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

