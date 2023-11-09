using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumenActual : MonoBehaviour, IDataPersiistence
{
    public Slider sliderMusic;
    public Slider sliderEfectos;

    public void LoadData(GameData _data)
    {
        sliderEfectos.value = _data.volumenEfectos;
        sliderMusic.value = _data.volumenMusic;
    }

    public void SaveData(ref GameData _data)
    {
            
    }
}