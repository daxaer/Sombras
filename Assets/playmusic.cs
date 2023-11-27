using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playmusic : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private AudioSource audio;
    private int currentClip;
    public void Start()
    {
        currentClip = 0;
        StartCoroutine("ReproducirMusica");
    }

   IEnumerator ReproducirMusica()
   {
        audio.clip = clips[currentClip];
        audio.Play();
        
        yield return new WaitForSeconds(audio.clip.length);
        currentClip = Random.Range(0, clips.Length);
        StartCoroutine("ReproducirMusica");
    }
}
