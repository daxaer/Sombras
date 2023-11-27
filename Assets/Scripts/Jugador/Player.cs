using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private VictoriaYDerrota gameEnd;
    private PlayerInput playerInput;
    private Rigidbody2D playerRb;
    public bool invulnerable;
    public SpriteRenderer[] sprite;
    public static Player Instance;
    public bool dead;
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
        dead = false;
        Time.timeScale = 1.0f;
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
        if (other.CompareTag("Alma"))
        {
            if(other.GetComponent<SpawnAlmas>().TipoAlma() == 1)
            {
                MusicManager.Instance.PlayAudioPool(SOUNDTYPE.GET_HEALTH, transform);
                EstadisticasManager.Instance.vidaActual += 1;
                EstadisticasManager.Instance.vidaActual = Mathf.Clamp(EstadisticasManager.Instance.vidaActual, 0, EstadisticasManager.Instance.vidaMaxima);
            }
            if (other.GetComponent<SpawnAlmas>().TipoAlma() == 2)
            {
                UIManager.Instance.Almas(1);
                EstadisticasManager.Instance.almasGuardadas++;
                EstadisticasManager.Instance.almas++;
                MusicManager.Instance.PlayAudioPool(SOUNDTYPE.GET_SOUL, transform);
            }
        }
    }
    public void Mori()
    {
        GameManager.Instance.JuegoPausado();
        ManageScenes.Instance.AbrirGameOver();
        Timer.Instance.rondaActual = 0;
        DataPersistenceManager.Instance.SaveGame();
    }

    public void Pausar()
    {
        ManageScenes.Instance.AbrirPausa();
    }

    public void TakeDamage(int damage)
    {
        if(invulnerable == false)
        {
            invulnerable = true;
            EstadisticasManager.Instance.vidaActual -= damage;
            MusicManager.Instance.PlayAudioPool(SOUNDTYPE.HIT_PLAYER, transform);
            VibracionCamara.Instance.MoviendoCamara(5, 5, 0.5f);
            if (EstadisticasManager.Instance.vidaActual <= 0)
            {
                dead = true;
                JuegoTerminado();
            }
            else
            {
                StartCoroutine("Invulnerabilidad");
            }
        }
    }
    public void JuegoTerminado()
    {
        gameEnd.gameObject.SetActive(true);
        gameEnd.scalaraura();
        if (dead) 
        {
            Invoke("Mori", 5f);
        }
    }
    IEnumerator Invulnerabilidad()
    {
        Debug.Log("Comenzando recuperacion");
        var transparencia = sprite[0].color.a;
        var transparencia1 = sprite[1].color.a;
        var transparencia2 = sprite[2].color.a;
        transparencia = 0f;
        transparencia1 = 0f;
        transparencia2 = 0f;
        yield return new WaitForSeconds(0.2f);
        transparencia = 1f;
        transparencia1 = 1f;
        transparencia2 = 1f;
        yield return new WaitForSeconds(0.2f);
        transparencia = 0f;
        transparencia1 = 0f;
        transparencia2 = 0f;
        yield return new WaitForSeconds(0.2f);
        transparencia = 1f;
        transparencia1 = 1f;
        transparencia2 = 1f;
        yield return new WaitForSeconds(0.2f);
        transparencia = 0f;
        transparencia1 = 0f;
        transparencia2 = 0f;
        yield return new WaitForSeconds(0.2f);
        transparencia = 1f;
        transparencia1 = 1f;
        transparencia2 = 1f;
        invulnerable = false;
        Debug.Log("terminada recuperacion");
    }
}