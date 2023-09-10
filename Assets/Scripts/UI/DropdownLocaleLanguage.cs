using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class DropdownLocaleLanguage : MonoBehaviour
{
    private const string LocaleKey = "SelectedKey";
    public string[] palabra;

    private void Start()
    {
        int savedLocalID = PlayerPrefs.GetInt(LocaleKey, 0);
        ChangeLocal(savedLocalID);
    }

    public void ChangeLocal(int localID)
    {
        var avaliableLocales = LocalizationSettings.AvailableLocales;
        if (localID >= 0 && localID < avaliableLocales.Locales.Count)
        {
            LocalizationSettings.SelectedLocale = avaliableLocales.Locales[localID];
            PlayerPrefs.SetInt(LocaleKey, localID);
        }
    }
}
