using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoPersonaje : MonoBehaviour
{
    public Estadisticas estadisticas;
    [SerializeField] private ScriptableObject personajeSeleccionado;
    private Vector3 _objetivoArma;
    [SerializeField] private Camera _camera;
    
    public float RangoVida { get { return (float)vidaActual / (float)vidaMaxima; } }
    
    private Vector2 direccion;
    
    private Rigidbody2D playerRb;

    [SerializeField] private BarraVida barraVida;
    [SerializeField] private Almas Alma;


    private  Vector2 rotacionPlayer;

    [SerializeField] private GameObject _objectOpenSettings;


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        vidaMaxima = 100;
        vidaActual = vidaMaxima;
        velocidadPlayer = 2;
        barraVida.EstablecerBarraVida(vidaActual);
    }

    void Update()
    {
        float angulo = Mathf.Atan2(_objetivoArma.y - transform.position.y, _objetivoArma.x - transform.position.x);
        float rotacion = (180 / Mathf.PI) * angulo - 90;
        transform.rotation = Quaternion.Euler(0, 0, rotacion);
        _objetivoArma = _camera.ScreenToWorldPoint(Input.mousePosition);

        Pause();
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
            vidaActual = vidaActual - 10f;
            vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);
            barraVida.ValorBarraPorcentual(RangoVida);
            barraVida.ValorVidaActual(vidaActual);
            
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

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _objectOpenSettings.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void closePause()
    {
        _objectOpenSettings.SetActive(false);
        Time.timeScale = 1f;
    }
}
