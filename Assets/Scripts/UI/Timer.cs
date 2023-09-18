using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Timer : MonoBehaviour
{
    public TransitionGameOver gameOver;
    public EventSystem eventSystem;
    [SerializeField] private float _timeRemaining = 180;
    [SerializeField] private float _tiempoInicial;
    [SerializeField] private bool _timeIsRunning = true;
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private SpawnManager spawn;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private GameObject tienda;
    [SerializeField] private GameObject retorno;
    [SerializeField] private SistemaDrop sistemDrop;
    public Pool pool;
    private bool stoptimer = true;
    [SerializeField] private int rondaActual;

    // Start is called before the first frame update
    void Start()
    {
        _timeIsRunning = true;
        _tiempoInicial = _timeRemaining;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_timeIsRunning)
        {
            _timeRemaining -= Time.deltaTime;
            if (_timeRemaining <= -1 && stoptimer)
            {
                if(rondaActual == 4)
                {
                    gameOver.Win();
                    stoptimer = false;
                }
                else
                {
                    rondaActual++;
                    stoptimer = false;
                    sistemDrop.AparicionTarjetaEnSlot(1);
                    sistemDrop.AparicionTarjetaEnSlot(2);
                    sistemDrop.AparicionTarjetaEnSlot(3);
                    tienda.SetActive(true);
                    eventSystem.SetSelectedGameObject(retorno);
                    PauseGame();
                }
            }
            else if(stoptimer)
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

    private void DeactivateEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) 
        {
            pool.DeactivateEnemy(enemy);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        _timeRemaining = _tiempoInicial;
        DisplayTime(_tiempoInicial);
        Time.timeScale = 1f;
        stoptimer = true;
    }
}