using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MovimientoPersonaje : MonoBehaviour
{
    public Estadisticas estadisticas;
    [SerializeField] private ScriptableObject personajeSeleccionado;
    private Vector3 _objetivoArma;
    [SerializeField] private Camera _camera;
    
    public float RangoVida { get { return (float)estadisticas.vidaActual / (float)estadisticas.vidaMaxima; } }
    
    private Vector2 direccionPlayer;
    
    private Rigidbody2D playerRb;


    [SerializeField] private BarraVida barraVida;
    [SerializeField] private Almas Alma;


    private  Vector2 rotacionPlayer;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

       
        barraVida.EstablecerBarraVida(estadisticas.vidaActual);

    }

    // Update is called once per frame
    void Update()
    {
        float angulo = Mathf.Atan2(_objetivoArma.y - transform.position.y, _objetivoArma.x - transform.position.x);
        float rotacion = (180 / Mathf.PI) * angulo - 90;
        transform.rotation = Quaternion.Euler(0, 0, rotacion);
        _objetivoArma = _camera.ScreenToWorldPoint(Input.mousePosition);

    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + direccionPlayer * (estadisticas.velocidadPlayer * Time.fixedDeltaTime));
        
    }
    

    public void moveDir(Vector2 direccion)
    {
        direccionPlayer = direccion;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            estadisticas.vidaActual = estadisticas.vidaActual - 10f;
            estadisticas.vidaActual = Mathf.Clamp(estadisticas.vidaActual, 0, estadisticas.vidaMaxima);
            barraVida.ValorBarraPorcentual(RangoVida);
            barraVida.ValorVidaActual(estadisticas.vidaActual);
            
        }
        if (collision.CompareTag("Alma"))
        {
             if (collision.GetComponent<SpawnAlmas>().TipoAlma() == 1)
             {
                 estadisticas.vidaActual = estadisticas.vidaActual + 10f;
                 estadisticas.vidaActual = Mathf.Clamp(estadisticas.vidaActual, 0, estadisticas.vidaMaxima);
                 barraVida.ValorBarraPorcentual(RangoVida);
                 barraVida.ValorVidaActual(estadisticas.vidaActual);
             }
             else
             {
                 Alma.CantidadAlmas = Alma.CantidadAlmas + 1;
             }
        }
    }


}
