using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Audio;
using System;
using Unity.Mathematics;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private GameObject _spawnSound;

    public SoundType[] libreriarDeSonidos;
    public AudioMixer mixer;

    public Pool _poolSounds;
    #region Singleton
    public static MusicManager Instance { get; private set; }

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    void Start()
    {
        _poolSounds = new Pool();
        _poolSounds.Inicializar(_spawnSound,10);
    }

    AudioClip GetClip(SOUNDTYPE _type) 
    {
        for (int i = 0; i < libreriarDeSonidos.Length; i++)
        {
            if (libreriarDeSonidos[i].type == _type)
            {
                return libreriarDeSonidos[i].GetRandomClip();
            }
        }
        return null;
    }

    public void PlayAudio(SOUNDTYPE _type)
    {
        GetComponent<AudioSource>().PlayOneShot(GetClip(_type));
    }
   
    public void PlayAudioPool(SOUNDTYPE _type, Transform _position)
    {
        GameObject currentsource = _poolSounds.SpawnSound(_position.position, _position.rotation);
        currentsource.gameObject.SetActive(true);
        if (currentsource != null)
        {
            AudioSource audio = currentsource.GetComponent<AudioSource>();
            audio.clip = GetClip(_type);
            audio.Play();
        }
    }

    public void VolumeMusic(float volume)
    {
        mixer.SetFloat("MusicVolume", volume);
    }
    public void VolumeEffects(float volume)
    {
        mixer.SetFloat("FxVolume", volume);
    }
}

[Serializable]
public class SoundType
{
    public SOUNDTYPE type;
    public AudioClip[] clip;

    public AudioClip GetRandomClip()
    {
        return clip[UnityEngine.Random.Range(0, clip.Length)];
    }
}

public enum SOUNDTYPE
{
    DEATH,
    HIT_ENEMY,
    HIT_PLAYER,
    GET_SOUL,
    GET_HEALTH,
    LIFE_STEAL,
    BUTTON_PRESS,
    BUTTON_SELECT,
    OPEN_UI,
}
