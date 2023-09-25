using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MovimientoPersonaje : MonoBehaviour
{
    public TransitionGameOver gameOver;
    public EventSystem eventSystem;
    public Estadisticas estadisticas;
    public GameObject botonRetornar;
    public SpriteRenderer sprite;

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
    bool invulnerable = false;
    
    [SerializeField] private Controles playerInputMap;

    public DeathCount _deathcount;


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        barraVida.EstablecerBarraVida(estadisticas.vidaActual);

        playerInputMap = new Controles();

        playerInputMap.Gameplay.Enable();
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
    public void  Mori()
    {
        if(estadisticas.vidaActual <=0)
        {
            gameOver.CargarGameOver();
            _deathcount.OnPlayerDeath();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && invulnerable == false)
        {
            invulnerable = true;
            recibiendoDano.Play();
            estadisticas.vidaActual = estadisticas.vidaActual - 10f;
            estadisticas.vidaActual = Mathf.Clamp(estadisticas.vidaActual, 0, estadisticas.vidaMaxima);
            barraVida.ValorBarraPorcentual(RangoVida);
            barraVida.ValorVidaActual(estadisticas.vidaActual);
            Mori();
            collision.GetComponent<Enemy>().Atacar();
            StartCoroutine("Invulnerabilidad");


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
                Alma.ActualizarAlmas();
            }
        }
    }

    public void RecuperarVIda(float vida)
    {
        estadisticas.vidaActual += vida;
        estadisticas.vidaActual = Mathf.Clamp(estadisticas.vidaActual, 0, estadisticas.vidaMaxima);
        barraVida.ValorBarraPorcentual(RangoVida);
        barraVida.ValorVidaActual(estadisticas.vidaActual);
        Debug.Log("recuperevida" + vida);
    }

 
    public void Pause()
    {
        if (playerInputMap.Gameplay.Pause.WasPressedThisFrame())
        {
            eventSystem.SetSelectedGameObject(botonRetornar);
            _objectOpenSettings.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void closePause()
    {
        _objectOpenSettings.SetActive(false);
        Time.timeScale = 1f;
    }

    IEnumerator Invulnerabilidad()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
        invulnerable = false;
    }
   
}
