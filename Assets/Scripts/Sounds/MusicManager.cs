using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource _effects;
    public static MusicManager Instance { get; private set; }

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public AudioSource Music { get { return _music; } }

    public AudioSource Effects { get { return _effects; } }

    public void VolumeMusic(float volume)
    {
        Music.volume = volume;
    }
    public void VolumeEffects(float volume)
    {
        Effects.volume = volume;
    }
}
