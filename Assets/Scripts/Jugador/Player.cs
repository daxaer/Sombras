using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody2D playerRb;
    private bool invulnerable = false;
    public SpriteRenderer sprite;
    public static Player Instance;
    

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
    }

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        
        if (playerInput.currentControlScheme == "consola")
        {

        }
        else
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(playerInput.actions["Look"].ReadValue<Vector2>());
            float angulo = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
            float rotacion = (180 / Mathf.PI) * angulo - 90;
            transform.rotation = Quaternion.Euler(0, 0, rotacion);
        }
        //if (rStickInput != Vector2.zero)
        //{
        //    Vector2 Direction = rStickInput.normalized;
        //    float distanciaDelJugador = 100f;

        //    _objetivoArma = transform.position + new Vector3(Direction.x, Direction.y, 0) * distanciaDelJugador;

        //    float angulo = Mathf.Atan2(transform.position.y - _objetivoArma.y, transform.position.x - _objetivoArma.x);
        //    float rotacion = (180 / Mathf.PI) * angulo;
        //    transform.rotation = Quaternion.Euler(0, 0, rotacion);
        //}
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + playerInput.actions["Movimiento"].ReadValue<Vector2>() * (EstadisticasManager.Instance.velocidadPlayer * Time.fixedDeltaTime));
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
