using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeRemaining = 0;
    [SerializeField] private bool _timeIsRunning = true;
    [SerializeField] private TMP_Text _timeText;

    // Start is called before the first frame update
    void Start()
    {
        _timeIsRunning = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_timeIsRunning)
        {
            _timeRemaining += Time.deltaTime;
            DisplayTime(_timeRemaining);
        }
    }

    void DisplayTime(float _timeToDisplay)
    {
        _timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(_timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(_timeToDisplay % 60);
        _timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}