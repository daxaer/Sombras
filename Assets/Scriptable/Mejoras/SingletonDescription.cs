using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SingletonDescription : MonoBehaviour
{
    public static SingletonDescription Instance;
    [SerializeField] private TextMeshProUGUI Description;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    public void TextMeshDescription(string _text)
    {
        Description.text = _text;
    }
}
