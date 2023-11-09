using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SwitchNameSelect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textPro;
    [SerializeField] private Image image;

    public void ReciveText(string _txtrecive)
    {
        textPro.text = _txtrecive;
    }

    public void ReciveImage(Sprite _image)
    {
        image.sprite = _image;
    }
}
