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
    public bool invulnerable;
    public SpriteRenderer[] sprite;
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
        invulnerable = false;
        playerRb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }
    void Update()
    {
        if (playerInput.currentControlScheme == "Gamepad")
        {
            Vector2 control = playerInput.actions["Look"].ReadValue<Vector2>();
            if(control != Vector2.zero)
            {
                float angulo = Mathf.Atan2(control.y - transform.position.z, control.x - transform.position.z);
                float rotacion = (180 / Mathf.PI) * angulo - 90;
                transform.rotation = Quaternion.Euler(0, 0, rotacion);
            }
        }

        if (playerInput.currentControlScheme == "Teclado")
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(playerInput.actions["Look"].ReadValue<Vector2>());
            float angulo = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
            float rotacion = (180 / Mathf.PI) * angulo - 90;
            transform.rotation = Quaternion.Euler(0, 0, rotacion);
        }
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + playerInput.actions["Move"].ReadValue<Vector2>() * (EstadisticasManager.Instance.velocidadPlayer * Time.fixedDeltaTime));
    }

    public void CambioDeControl(PlayerInput player)
    {
        if(player.currentControlScheme == "Gamepad")
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void RecuperarVIda(int vida)
    {
        EstadisticasManager.Instance.vidaActual += vida;
        EstadisticasManager.Instance.vidaActual = Mathf.Clamp(EstadisticasManager.Instance.vidaActual, 0, EstadisticasManager.Instance.vidaMaxima);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemies>().Atacar();
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

    }
    public void Pausar()
    {
        GameManager.Instance.JuegoPausado();
        ManageScenes.Instance.AbrirPausa();
    }
    public void TakeDamage()
    {
        if (EstadisticasManager.Instance.vidaActual <= 0)
        {
            Mori();
        }
        else
        {
            StartCoroutine("Invulnerabilidad");
        }
    }
    IEnumerator Invulnerabilidad()
    {
        var transparencia = sprite[0].color.a;
        var transparencia1 = sprite[1].color.a;
        var transparencia2 = sprite[2].color.a;
        transparencia = 0.2f;
        transparencia1 = 0.2f;
        transparencia2 = 0.2f;
        yield return new WaitForSeconds(0.1f);
        transparencia = 1f;
        transparencia1 = 1f;
        transparencia2 = 1f;
        yield return new WaitForSeconds(0.1f);
        transparencia = 0.2f;
        transparencia1 = 0.2f;
        transparencia2 = 0.2f;
        yield return new WaitForSeconds(0.1f);
        transparencia = 1f;
        transparencia1 = 1f;
        transparencia2 = 1f;
        yield return new WaitForSeconds(0.1f);
        transparencia = 0.2f;
        transparencia1 = 0.2f;
        transparencia2 = 0.2f;
        yield return new WaitForSeconds(0.1f);
        transparencia = 1f;
        transparencia1 = 1f;
        transparencia2 = 1f;
        invulnerable = false;
    }
}
