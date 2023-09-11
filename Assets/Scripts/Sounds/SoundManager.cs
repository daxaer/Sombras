using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider effectSlider;
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource _effects;
    [SerializeField] private AudioMixer _mixer;

    public Slider VolumeSlider { get { return volumeSlider; } }

    public Slider VolumeEffects { get { return effectSlider; } }

    public AudioSource Music { get { return _music; } }

    public AudioSource Effects { get { return _effects; } }

    private static SoundManager instance;


    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SubirVolumen()
    {
        VolumeSlider.value += 0.1f;
        _music.volume = VolumeSlider.value;
    }

    public void BajarVolumen()
    {
        VolumeSlider.value -= 0.1f;
        _music.volume = VolumeSlider.value;
    }

    public void SubirVolumenEffects()
    {
        VolumeEffects.value += 0.1f;
        _effects.volume = VolumeEffects.value;
    }

    public void BajarVolumenEffects()
    {
        VolumeEffects.value -= 0.1f;
        _effects.volume = VolumeEffects.value;
    }

    public float ValueVolume(float volume)
    {
        _mixer.SetFloat("Music", volume);
        volume = VolumeSlider.value;
        return volume;
    }

    public float ValueEffects(float volume)
    {
        _mixer.SetFloat("Effects", volume);
        volume = VolumeEffects.value;
        return volume;
    }

    /*public Slider ValueSliderMusic(Slider _volumeSliderMusic)
    {
        _volumeSliderMusic = VolumeSlider.value;
        return _volumeSliderMusic;
    }*/
}
