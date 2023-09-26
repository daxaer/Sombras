using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Audio;
using System;

public class MusicManager : MonoBehaviour
{
   // [SerializeField] private AudioSource _music;
    //[SerializeField] private AudioSource _effects;

    public AudioSource[] sources;
    public SoundType[] libreriarDeSonidos;
    public AudioMixer mixer;

    #region Singleton
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
    #endregion

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

    public void PlayAudio(SOUNDTYPE _type, Vector3 _position)
    {
        AudioSource currentsource = GetAudioSource();
        if(currentsource != null)
        {
            currentsource.transform.position = _position;
            currentsource.clip = GetClip(_type);
            currentsource.Play();
        }
    }

    AudioSource GetAudioSource()
    {
        for(int i = 0; i < sources.Length; i++)
        {
            if(!sources[i].isPlaying)
            {
                return sources[i];
            }
           
        }
        return null;
    }
    /*public AudioSource Music { get { return _music; } }

    public AudioSource Effects { get { return _effects; } }

    public void VolumeMusic(float volume)
    {
        Music.volume = volume;
    }
    public void VolumeEffects(float volume)
    {
        Effects.volume = volume;
    }*/

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
