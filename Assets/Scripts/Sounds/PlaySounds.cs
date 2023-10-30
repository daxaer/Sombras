using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{
    [SerializeField] private SOUNDTYPE soundType;
    [SerializeField] private Transform posicion;
    public void Play()
    {
        MusicManager.Instance.PlayAudioPool(soundType, posicion);
    }
}
