using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource _effects;

    public AudioSource Music { get { return _music; } }

    public AudioSource Effects { get { return _effects; } }


    public void SubirVolumen()
    {
        volumeSlider.value += 0.1f;
    }

    public void BajarVolumen()
    {
        volumeSlider.value -= 0.1f;
    }
}
