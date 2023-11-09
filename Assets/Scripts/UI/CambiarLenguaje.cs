using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class CambiarLengauje : MonoBehaviour, IDataPersiistence
{
    [SerializeField] private int LenguajeText;
    [SerializeField] private TextMeshProUGUI text;
    private int idioma;

    public void OnEnable()
    {
        LenguajeText = GameManager.Instance.ChangeLenguageTarget();
        CambiarTexto(LenguajeText);

    }
    public void Start()
    {
        CambiarTexto(LenguajeText);

    }
    public void CambiarLengaje(int lenguaje)
    {
        GameManager.Instance.ChangeLocal(lenguaje);
        CambiarTexto(lenguaje);
        idioma = lenguaje;
    }

    public void CambiarTexto(int texto)
    {
        if (texto == 0)
        {
            text.text = "Español";
        }
        else if (texto == 1)
        {
            text.text = "English";
        }
    }

    public void LoadData(GameData _data)
    {

    }

    public void SaveData(ref GameData _data)
    {
        _data.idioma = idioma;
    }
}