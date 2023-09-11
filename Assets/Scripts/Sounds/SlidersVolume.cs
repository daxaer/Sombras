using UnityEngine;
using UnityEngine.UI;

public class SlidersVolume : MonoBehaviour
{

    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider effectSlider;
    [SerializeField] private MusicManager musicManager;
    [SerializeField] private float valueEffects;
    [SerializeField] private float valueMusic;


    public void SubirVolumenEffects()
    {
        effectSlider.value += 0.1f;
        musicManager.VolumeEffects(effectSlider.value);
    }

    public void BajarVolumenEffects()
    {
        effectSlider.value -= 0.1f;
        musicManager.VolumeEffects(effectSlider.value);
    }

    public void SubirVolumen()
    {
        volumeSlider.value += 0.1f;
        musicManager.VolumeMusic(volumeSlider.value);
    }

    public void BajarVolumen()
    {
        volumeSlider.value -= 0.1f;
        musicManager.VolumeMusic(volumeSlider.value);
    }
}
