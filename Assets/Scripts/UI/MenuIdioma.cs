using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
public class MenuIdioma : MonoBehaviour
{

    private int lenguaje;

    // Start is called before the first frame update
    void Start()
    {
        CargarIdioma();
        Invoke(nameof(CargaLocal), 0.1f);
    }

    private void CargaLocal()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[lenguaje];
    }

    public void CambiarLenguaje(int indiceLenguaje)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[indiceLenguaje];
        lenguaje = indiceLenguaje;
        GuardarIdioma();
    }
    private void GuardarIdioma()
    {
        PlayerPrefs.SetInt("idioma", lenguaje);
    }

    private void CargarIdioma()
    {
        lenguaje = PlayerPrefs.GetInt("idioma");
    }

   
}
