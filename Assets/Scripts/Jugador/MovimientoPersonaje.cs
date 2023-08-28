using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidadPlayer { get; private set; }
    public float vidaMaxima { get; private set; }
    public float vidaActual { get; private set; }
    
    public float rango { get; private set; }
    public float VelocidadAtaque { get; private set; }
    public float roboDeVida { get; private set; }
    public bool iluminarEnemigo { get; private set; }
    public float duracionLamparas { get; private set; }
    public float rangoLamparas { get; private set; }

    private Vector3 _objetivoArma;
    [SerializeField] private Camera _camera;
    
    public float RangoVida { get { return (float)vidaActual / (float)vidaMaxima; } }
    
    private Vector2 direccion;
    
    private Rigidbody2D playerRb;

    

    [SerializeField] private BarraVida barraVida;
    [SerializeField] private Almas Alma;



    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        vidaMaxima = 100;
        vidaActual = vidaMaxima;
        velocidadPlayer = 2;
        barraVida.EstablecerBarraVida(vidaActual);

    }

    // Update is called once per frame
    void Update()
    {
        float direccionX = Input.GetAxisRaw("Horizontal");
        float direccionY = Input.GetAxisRaw("Vertical");
        direccion = new Vector2(direccionX, direccionY).normalized;

        _objetivoArma = _camera.ScreenToWorldPoint(Input.mousePosition);

        float angulo = Mathf.Atan2(_objetivoArma.y - transform.position.y, _objetivoArma.x - transform.position.x);
        float rotacion = (180 / Mathf.PI) * angulo - 90;
        transform.rotation = Quaternion.Euler(0,0,rotacion);

        //Prueba de aumento de velocidad a la hora de hacer la compra
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocidadPlayer++;
        }


    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + direccion * (velocidadPlayer * Time.fixedDeltaTime));
    }

    //Prueba de cuando toque un enemigo baje su vida, en este caso son capsulas que deje en el mapa
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            vidaActual = vidaActual - 10f;
            vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);
            barraVida.ValorBarraPorcentual(RangoVida);
            barraVida.ValorVidaActual(vidaActual);
            
            //barraVida.barraAnimator.SetBool("estaBaja", true);
        }
        if (collision.CompareTag("Alma"))
        {
            if (collision.GetComponent<SpawnAlmas>().TipoAlma() == 1)
            {
                vidaActual = vidaActual + 10f;
                vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);
                barraVida.ValorBarraPorcentual(RangoVida);
                barraVida.ValorVidaActual(vidaActual);
            }
            else
            {
                Alma.CantidadAlmas = Alma.CantidadAlmas + 1;
            }
        }
    }


}
