using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIRonda : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ronda;

    private void Start()
    {
        ActualizarRonda();
    }
    public void ActualizarRonda()
    {
        ronda.text = (Timer.Instance.rondaActual + 1).ToString();
    }
}
