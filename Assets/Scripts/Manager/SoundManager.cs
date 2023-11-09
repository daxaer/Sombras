using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Audio;
using System;
using Unity.Mathematics;

public class MusicManager : MonoBehaviour, IDataPersiistence
{
    [SerializeField] private GameObject _spawnSound;

    public SoundType[] libreriarDeSonidos;
    public AudioMixer mixer;

    public Pool _poolSounds;

    private float volumenMusica;
    private float volumenEfectos;

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
        _poolSounds.Inicializar(_spawnSound,1);
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
        GameObject currentsource = _poolSounds.Spawn(_position.position, _position.rotation);
        AudioSource audio = currentsource.GetComponent<AudioSource>();
        audio.clip = GetClip(_type);
        currentsource.GetComponent<DesactivarAudio>().tiempo = audio.clip.length;
        audio.Play();
    }

    public void VolumeMusic(float volume)
    {
        mixer.SetFloat("MusicVolume", volume);
        volumenMusica = volume;
    }
    public void VolumeEffects(float volume)
    {
        mixer.SetFloat("FxVolume", volume);
        volumenEfectos = volume;
    }
    public void SetVolume()
    {
        VolumeEffects(volumenEfectos);
        VolumeMusic(volumenMusica);
    }

    public void LoadData(GameData _data)
    {
        volumenMusica = _data.volumenMusic;
        volumenEfectos = _data.volumenEfectos;
        Invoke("SetVolume", 0.01f);
    }

    public void SaveData(ref GameData _data)
    {
        _data.volumenMusic = volumenMusica;
        _data.volumenEfectos = volumenEfectos;
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
    HIT_ENEMY_MELE,
    SLASH,
    RANGE,
    HIT_ENEMY_RANGE,
    HIT_PLAYER,
    GET_SOUL,
    GET_HEALTH,
    LIFE_STEAL,
    BUTTON_PRESS,
    BUTTON_SELECT,
    OPEN_UI,
    HIT_PARED,
    FIRE_RANGE,
    ENEMY_EXPLOSION,
    LIGHT,
    END_lIGHT,
}
