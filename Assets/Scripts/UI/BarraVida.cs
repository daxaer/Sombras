using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    
    [SerializeField] private Slider barraVida;
    public Animator barraAnimator;
    public Image MaskBarra;
    public float velocidadBarra;

    private float valorBarraFinal;

    // Start is called before the first frame update
    private void Awake()
    {
        MaskBarra.fillAmount = 1f;
        valorBarraFinal = MaskBarra.fillAmount;
    }
    void Start()
    {
        barraVida = GetComponent<Slider>();
        barraAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(MaskBarra.fillAmount != valorBarraFinal)
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
