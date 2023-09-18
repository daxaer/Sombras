using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Almas : MonoBehaviour
{
    [SerializeField] private Text textoAlmas;
    public int CantidadAlmas;

    void Start()
    {
        textoAlmas = GetComponent<Text>();
        textoAlmas.text = CantidadAlmas.ToString();
    }
    public void ActualizarAlmas()
    {
        textoAlmas.text = CantidadAlmas.ToString();
    }
}
