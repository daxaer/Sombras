using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class CambiarLengauje : MonoBehaviour
{
    public void CambiarLengaje(int lenguaje)
    {
        GameManager.Instance.ChangeLocal(lenguaje);
    }
}