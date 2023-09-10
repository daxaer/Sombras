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

    public float RangoVida { get { return (float)estadisticas.vidaActual / (float)estadisticas.vidaMaxima; } }

    private Vector2 direccionPlayer;
    
    private Rigidbody2D playerRb;

    [SerializeField] private BarraVida barraVida;
    [SerializeField] private Almas Alma;

    [SerializeField] private GameObject _objectOpenSettings;


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        barraVida.EstablecerBarraVida(estadisticas.vidaActual);
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

    //Prueba de cuando toque un enemigo baje su vida, en este caso son capsulas que deje en el mapa

    public void moveDir(Vector2 direccion)
    {
        direccionPlayer = direccion;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
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
