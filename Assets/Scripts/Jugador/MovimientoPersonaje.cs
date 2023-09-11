using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MovimientoPersonaje : MonoBehaviour
{
    public Estadisticas estadisticas;

    private Vector3 _objetivoArma;
    [SerializeField] private Camera _camera;
    public float RangoVida { get { return (float)estadisticas.vidaActual / (float)estadisticas.vidaMaxima; } }

    private Vector2 direccionPlayer;
    
    private Rigidbody2D playerRb;

    [SerializeField] private BarraVida barraVida;
    [SerializeField] private Almas Alma;

    [SerializeField] private GameObject _objectOpenSettings;

    public AudioSource recibiendoDano;
    public Transform player;
    Vector2 rStickInput = Vector2.zero;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        barraVida.EstablecerBarraVida(estadisticas.vidaActual);
    }

    void Update()
    {
        Vector2 rStickInput = new Vector2(Input.GetAxis("4 Axis"), Input.GetAxis("5 Axis"));

        if (rStickInput != Vector2.zero)
        {
            Vector2 Direction = rStickInput.normalized;
            float distanciaDelJugador = 100f;

            _objetivoArma = transform.position + new Vector3(Direction.x, Direction.y, 0) * distanciaDelJugador;

            float angulo = Mathf.Atan2(transform.position.y - _objetivoArma.y, transform.position.x - _objetivoArma.x);
            float rotacion = (180 / Mathf.PI) * angulo - 90;
            player.transform.rotation = Quaternion.Euler(0, 0, rotacion);
        }
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
        if (collision.CompareTag("Enemy"))
        {
            recibiendoDano.Play();
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
