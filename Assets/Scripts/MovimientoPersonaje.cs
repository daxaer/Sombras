using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MovimientoPersonaje : MonoBehaviour
{
<<<<<<< Updated upstream:Assets/Scripts/MovimientoPersonaje.cs
    public float velocidadPlayer { get; private set; }
    public float vidaMaxima { get; private set; }
    public float vidaActual { get; private set; }

    public float RangoVida { get { return (float)vidaActual / (float)vidaMaxima; } }
=======
    public Estadisticas estadisticas;

    private Vector3 _objetivoArma;
    [SerializeField] private Camera _camera;
    
    public float RangoVida { get { return (float)estadisticas.vidaActual / (float)estadisticas.vidaMaxima; } }
>>>>>>> Stashed changes:Assets/Scripts/Jugador/MovimientoPersonaje.cs
    
    private Vector2 direccionPlayer;
    
    private Rigidbody2D playerRb;


    [SerializeField] private BarraVida barraVida;
    [SerializeField] private Almas Alma;

    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

       
        barraVida.EstablecerBarraVida(estadisticas.vidaActual);

    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream:Assets/Scripts/MovimientoPersonaje.cs
        float direccionX = Input.GetAxisRaw("Horizontal");
        float direccionY = Input.GetAxisRaw("Vertical");
        direccion = new Vector2(direccionX, direccionY).normalized;

=======
        _objetivoArma = _camera.ScreenToWorldPoint(Input.mousePosition);
>>>>>>> Stashed changes:Assets/Scripts/Jugador/MovimientoPersonaje.cs


    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + direccionPlayer * (estadisticas.velocidadPlayer * Time.fixedDeltaTime));
    }

    public void moveDir(Vector2 direccion)
    {
        direccionPlayer = direccion;
    }

    //Prueba de cuando toque un enemigo baje su vida, en este caso son capsulas que deje en el mapa
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            estadisticas.vidaActual = estadisticas.vidaActual - 10f;
            estadisticas.vidaActual = Mathf.Clamp(estadisticas.vidaActual, 0, estadisticas.vidaMaxima);
            barraVida.ValorBarraPorcentual(RangoVida);
            barraVida.ValorVidaActual(estadisticas.vidaActual);
            
            //barraVida.barraAnimator.SetBool("estaBaja", true);
        }
        if (collision.CompareTag("Alma"))
        {
<<<<<<< Updated upstream:Assets/Scripts/MovimientoPersonaje.cs
            Alma.CantidadAlmas = Alma.CantidadAlmas + 1;
=======
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
>>>>>>> Stashed changes:Assets/Scripts/Jugador/MovimientoPersonaje.cs
        }
    }


}
