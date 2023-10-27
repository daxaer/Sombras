using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Controles playerInput;
    private Rigidbody2D playerRb;
    private bool invulnerable = false;
    public SpriteRenderer sprite;
    public static Player Instance;
    Vector2 move;
    Vector2 rotation;
    [SerializeField] private float velocidadDeRotacion = 5.0f;

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

        playerInput = new Controles();

        playerInput.Gameplay.Movimiento.performed += ctx => move = ctx.ReadValue<Vector2>();
        playerInput.Gameplay.Movimiento.canceled += ctx => move = Vector2.zero;

        playerInput.Gameplay.Look.performed += ctx => rotation = ctx.ReadValue<Vector2>();
        playerInput.Gameplay.Look.canceled += ctx => rotation = Vector2.zero;
    }

    private void OnEnable()
    {
        playerInput.Gameplay.Enable();
    }

    private void OnDisable()
    {
        playerInput.Gameplay.Disable(); 
    }

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        //playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        
        /*if (playerInput.currentControlScheme == "consola")
        {

        }
        else
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(playerInput.actions["Look"].ReadValue<Vector2>());
            float angulo = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
            float rotacion = (180 / Mathf.PI) * angulo - 90;
            transform.rotation = Quaternion.Euler(0, 0, rotacion);
        }*/
        //if (rStickInput != Vector2.zero)
        //{
        //    Vector2 Direction = rStickInput.normalized;
        //    float distanciaDelJugador = 100f;

        //    _objetivoArma = transform.position + new Vector3(Direction.x, Direction.y, 0) * distanciaDelJugador;

        //    float angulo = Mathf.Atan2(transform.position.y - _objetivoArma.y, transform.position.x - _objetivoArma.x);
        //    float rotacion = (180 / Mathf.PI) * angulo;
        //    transform.rotation = Quaternion.Euler(0, 0, rotacion);
        //}

        Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime;
        transform.Translate(m, Space.World);

        Vector2 r = rotation * Time.deltaTime * velocidadDeRotacion;
        transform.Rotate(new Vector3(0, 0, -r.x), Space.World);
    }

    public void CambioDeControl(PlayerInput player)
    {
        if(player.currentControlScheme == "Consola")
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void RecuperarVIda(int vida)
    {
        EstadisticasManager.Instance.vidaActual += vida;
        EstadisticasManager.Instance.vidaActual = Mathf.Clamp(EstadisticasManager.Instance.vidaActual, 0, EstadisticasManager.Instance.vidaMaxima);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy") && invulnerable == false)
        {
            invulnerable = true;
            Enemies enemigo = other.GetComponent<Enemies>();
            enemigo.Atacar();
            if (EstadisticasManager.Instance.vidaActual <= 0)
            {
                Mori();
            }
            //MusicManager.Instance.PlayAudio(SOUNDTYPE.HIT_PLAYER, transform.position);
            StartCoroutine("Invulnerabilidad");
        }
        if (other.CompareTag("Alma"))
        {
            if(other.GetComponent<SpawnAlmas>().TipoAlma() == 1)
            {
                EstadisticasManager.Instance.vidaActual += 1;
                EstadisticasManager.Instance.vidaActual = Mathf.Clamp(EstadisticasManager.Instance.vidaActual, 0, EstadisticasManager.Instance.vidaMaxima);
            }
            if (other.GetComponent<SpawnAlmas>().TipoAlma() == 2)
            {
                UIManager.Instance.Almas(1);
            }
        }
    }

    public void Mori()
    {
        GameManager.Instance.JuegoPausado();
        ManageScenes.Instance.AbrirGameOver();
        //MusicManager.Instance.PlayAudio(SOUNDTYPE.DEATH);
    }
    public void Pausar()
    {
        GameManager.Instance.JuegoPausado();
        ManageScenes.Instance.AbrirPausa();
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
