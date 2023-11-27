using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using System.Collections;

public class Timer : MonoBehaviour, IDataPersiistence
{
    public EventSystem eventSystem;
    [SerializeField] public float _timeRemaining = 180;
    [SerializeField] private float _tiempoInicial;
    [SerializeField] private bool _timeIsRunning = true;
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private SpawnManager spawn;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private GameObject tienda;
    [SerializeField] private GameObject retorno;
    [SerializeField] private SistemaDrop sistemDrop;
    public Pool pool;
    public bool _stoptimer = true;
    public int rondaActual;
    public static Timer Instance;

    [SerializeField] GuardarJuego guardar;

    void Start()
    {
        _timeIsRunning = true;
        _tiempoInicial = _timeRemaining;
    }

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

    private void Update()
    {
        if (_timeIsRunning)
        {
            _timeRemaining -= Time.deltaTime;
            if (_timeRemaining <= -1 && _stoptimer)
            {
                if(rondaActual == 9)
                {
                    Player.Instance.JuegoTerminado();
                    StartCoroutine("victoria");
                }
                else
                {
                    guardar.Guardar();
                    rondaActual++;
                    _stoptimer = false;
                    sistemDrop.AparicionTarjetaEnSlot(1);
                    sistemDrop.AparicionTarjetaEnSlot(2);
                    sistemDrop.AparicionTarjetaEnSlot(3);
                    tienda.SetActive(true);
                    GameManager.Instance.JuegoPausado();
                }
            }
            else if(_stoptimer)
            {
                DisplayTime(_timeRemaining);
            }
  
        }
    }

    void DisplayTime(float _timeToDisplay)
    {
        _timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(_timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(_timeToDisplay % 60);
        _timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void RestartTimer()
    {
        if (rondaActual < 11)
        {
            _tiempoInicial += 15;
        }

        _timeRemaining = _tiempoInicial;
        DisplayTime(_tiempoInicial);
        _stoptimer = true;
    }

    public void LoadData(GameData _data)
    {
        rondaActual = _data.rondaActual;
    }

    public void SaveData(ref GameData _data)
    {
       
    }
    IEnumerator victoria()
    {
        yield return new WaitForSeconds(5f);
        ManageScenes.Instance.AbrirWin();
        _stoptimer = false;
        GameManager.Instance.JuegoPausado();
        rondaActual = 0;
    }
}