using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    [TextArea]
    public string[] differentLenguage;

    public string GetDialogue(byte _currentLanguage)
    {
        return differentLenguage[_currentLanguage];
    }
}
