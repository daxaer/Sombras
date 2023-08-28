using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoPersonaje : MonoBehaviour
{
    [SerializeField] private float velocidadPlayer = 1f;
    [SerializeField] private float vidaMaxima;
    [SerializeField] private float vidaActual;
    private Vector2 direccion;
    private Rigidbody2D playerRb;

    [SerializeField] private BarraVida barraVida;
    [SerializeField] private Almas Alma;



    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        

        vidaActual = vidaMaxima;
        barraVida.EstablecerBarraVida(vidaActual);

    }

    // Update is called once per frame
    void Update()
    {
        float direccionX = Input.GetAxisRaw("Horizontal");
        float direccionY = Input.GetAxisRaw("Vertical");
        direccion = new Vector2(direccionX, direccionY).normalized;



        //Prueba de aumento de velocidad a la hora de hacer la compra
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocidadPlayer++;
        }


    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + direccion * velocidadPlayer * Time.fixedDeltaTime);
    }

    //Prueba de cuando toque un enemigo baje su vida, en este caso son capsulas que deje en el mapa
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            vidaActual = vidaActual - 1f;
            barraVida.ValorVidaActual(vidaActual);
            barraVida.barraAnimator.SetBool("estaBaja", true);
        }
        if (collision.CompareTag("Alma"))
        {
            Alma.CantidadAlmas = Alma.CantidadAlmas + 1;
        }
    }


}
