using System;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    private static LanguageManager _instance;

    [SerializeField]
    LANGUAGES currentLanguage;

    public event Action<byte> OnLanguageChange;

    private void Awake()
    {
        _instance = this;
    }

    public static LanguageManager GetInstance()
    {
        return _instance;
    }

    public void SetCurrentLanguage(LANGUAGES _language) //Jalar desde la consola
    {
        currentLanguage = _language;
        SendEvent();
    }

    public void SetCurrentLanguage(bool up) //modificamos desde el menu
    {
        if (up)
        {
            currentLanguage++;
            if (currentLanguage >= LANGUAGES.COUNT)
            {
                currentLanguage = 0;
            }
        }
        else
        {
            currentLanguage--;
            if (currentLanguage <0)
            {
                currentLanguage = LANGUAGES.COUNT-1;
            }

        }
        SendEvent();
    }

    void SendEvent()
    {
        if (OnLanguageChange != null)
        {
            OnLanguageChange((byte)currentLanguage);
        }
    }

    public byte GetCurrentLanguage()
    {
        return (byte)currentLanguage;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SetCurrentLanguage(true);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SetCurrentLanguage(false);
        }
    }
}

public enum LANGUAGES
{
    ENGLISH,
    SPANISH,
    JAPANESE,
    COUNT
}
