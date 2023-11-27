using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IDataPersiistence
{
    [SerializeField] private TextMeshProUGUI textoAlmas;
    [SerializeField] private TextMeshProUGUI textovida;
    [SerializeField] Slider slidervida;
    [SerializeField] Slider hitSlider;
    private float hitDelay = 1f;
    private float nextupdate;
    private int almas;
    private float vidaAnterior;
    bool actualizar = false;
    bool playerSpawneo = false;

    public static UIManager Instance;
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
    public void Start()
    {
        vidaAnterior = EstadisticasManager.Instance.vidaActual;
        AlmasActuales();
        ActualizarVidaMaxima();
        UpdateVida();
        playerSpawneo = true;
    }
    private void Update()
    {
        UpdateVida();
    }
    public void AlmasActuales()
    {
       textoAlmas.text = almas.ToString();
    }

    public void Almas(int _almas)
    {
        almas += _almas;
        AlmasActuales();
    }

    public int GetAlmas()
    {
        return almas;
    }

    public void RecibirDaño()
    {
        slidervida.value = EstadisticasManager.Instance.vidaActual;
        textovida.text = (EstadisticasManager.Instance.vidaActual.ToString() + " / " + EstadisticasManager.Instance.vidaMaxima.ToString());
    }
    
    public void ActualizarVidaMaxima()
    {
        slidervida.maxValue = EstadisticasManager.Instance.vidaMaxima;
        hitSlider.maxValue = EstadisticasManager.Instance.vidaMaxima;
    }

    public void UpdateVida()
    {
        if (EstadisticasManager.Instance.vidaActual >= 0 && playerSpawneo)
        {
            slidervida.value = EstadisticasManager.Instance.vidaActual;
            textovida.text = (EstadisticasManager.Instance.vidaActual.ToString() + " / " + EstadisticasManager.Instance.vidaMaxima.ToString());
            if (EstadisticasManager.Instance.vidaActual <= 0)
            {
                EstadisticasManager.Instance.velocidadPlayer = 0;
                Player.Instance.dead = true;
                Player.Instance.JuegoTerminado();
            }
        }
        else if (playerSpawneo)
        {
            EstadisticasManager.Instance.velocidadPlayer = 0;
            Player.Instance.dead = true;
            Player.Instance.JuegoTerminado();
        }
        
        if (EstadisticasManager.Instance.vidaActual < vidaAnterior && !actualizar)
        {
            nextupdate = Time.time + hitDelay;
            actualizar = true;
        }
        if(Time.time > nextupdate)
        {
            if(EstadisticasManager.Instance.vidaActual < vidaAnterior)
            {
                vidaAnterior -= 1;
            }
            else
            {
                vidaAnterior = EstadisticasManager.Instance.vidaActual;
            }
            if(vidaAnterior == EstadisticasManager.Instance.vidaActual)
            {
                actualizar = false;
            }
            hitSlider.value = vidaAnterior;
        }
    }

    public void LoadData(GameData _data)
    {
        almas = EstadisticasManager.Instance.almas;
        AlmasActuales();
    }

    public void SaveData(ref GameData _data)
    {
        
    }
}

