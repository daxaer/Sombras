using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource _effects;
    [SerializeField] private float MusicVolume;
    [SerializeField] private float EffectsTemporal;

    private static MusicManager instance;

    public static MusicManager MusicInstance { get { return instance; } }

    public void Awake()
    {
        if (instance == null && MusicInstance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            Music.volume = MusicVolume;
            Effects.volume = EffectsTemporal;
        }
    }

    public AudioSource Music { get { return _music; } }

    public AudioSource Effects { get { return _effects; } }

    public void VolumeMusic(float volume)
    {
        Music.volume = volume;
        MusicVolume = volume;
    }

    public void VolumeEffects(float volume)
    {
        Effects.volume = volume;
        EffectsTemporal = volume;
    }

}
