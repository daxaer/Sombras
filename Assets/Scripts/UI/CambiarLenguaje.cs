using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class CambiarLengauje : MonoBehaviour
{
    [SerializeField] private int LenguajeText;
    [SerializeField] private TextMeshProUGUI text;

    public void OnEnable()
    {
        LenguajeText = GameManager.Instance.ChangeLenguageTarget();

        CambiarTexto(LenguajeText);
        Debug.Log("Lenguaje Actual" + LenguajeText);
    }
    public void CambiarLengaje(int lenguaje)
    {
        GameManager.Instance.ChangeLocal(lenguaje - 1);
        CambiarTexto(lenguaje - 1);
    }

    public void CambiarTexto(int texto)
    {
        if (texto == 0)
        {
            text.text = "Español";
        }
        else
        {
            text.text = "English";
        }

    }
}