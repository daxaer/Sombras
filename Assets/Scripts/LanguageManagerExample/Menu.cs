using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    public Dialogue Title;
    public TextMeshProUGUI _titleText;

    public Dialogue Subtitle;
    public TextMeshProUGUI _subtitleText;

    public Dialogue ButtonPlay;
    public TextMeshProUGUI _buttonPlayText;

    public Dialogue ButtonSettings;
    public TextMeshProUGUI _buttonSettingsText;

    public Dialogue ButtonCredits;
    public TextMeshProUGUI _buttonCreditsText;
    
    public Dialogue ButtonExit;
    public TextMeshProUGUI _buttonExitText;

    private void OnEnable()
    {
        LanguageManager.GetInstance().OnLanguageChange += UpdateTexts;
        _titleText.text = Title.GetDialogue(LanguageManager.GetInstance().GetCurrentLanguage());
        _subtitleText.text = Subtitle.GetDialogue(LanguageManager.GetInstance().GetCurrentLanguage());
        _buttonPlayText.text = ButtonPlay.GetDialogue(LanguageManager.GetInstance().GetCurrentLanguage());
        _buttonSettingsText.text = ButtonSettings.GetDialogue(LanguageManager.GetInstance().GetCurrentLanguage());
        _buttonCreditsText.text = ButtonCredits.GetDialogue(LanguageManager.GetInstance().GetCurrentLanguage());
        _buttonExitText.text = ButtonExit.GetDialogue(LanguageManager.GetInstance().GetCurrentLanguage());
    }

    private void OnDisable()
    {
        LanguageManager.GetInstance().OnLanguageChange -= UpdateTexts;
    }

    void UpdateTexts(byte _currentLanguage)
    {
        _titleText.text = Title.GetDialogue(_currentLanguage);
        _subtitleText.text = Subtitle.GetDialogue(_currentLanguage);
        _buttonPlayText.text = ButtonPlay.GetDialogue(_currentLanguage);
        _buttonSettingsText.text = ButtonSettings.GetDialogue(_currentLanguage);
        _buttonExitText.text = ButtonExit.GetDialogue(_currentLanguage);
    }
}
