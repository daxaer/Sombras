using UnityEngine;
using UnityEngine.UI;

public class MultilanguageText : MonoBehaviour
{
    Text text;
    [SerializeField][TextArea]
    string[] textToDisplay;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    void Start()
    {
        UpdateLanguage(LanguageManager.GetInstance().GetCurrentLanguage());
    }

    private void OnEnable()
    {
        LanguageManager.GetInstance().OnLanguageChange += UpdateLanguage;
    }

    private void OnDisable()
    {
        LanguageManager.GetInstance().OnLanguageChange -= UpdateLanguage;
    }

    void UpdateLanguage(byte _currentLanguage)
    {
        text.text = textToDisplay[_currentLanguage];
    }
}
