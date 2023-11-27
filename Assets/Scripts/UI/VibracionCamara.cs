using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VibracionCamara : MonoBehaviour
{
    public static VibracionCamara Instance;
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;

    private float tiempoMoviendose;

    private float tiempoMovimientoTotal;

    private float intesidadInicial;

   
    private void Awake()
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }


    public void MoviendoCamara(float intensidad, float frecuencia, float tiempo)
    {
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensidad;
        cinemachineBasicMultiChannelPerlin.m_FrequencyGain = frecuencia;
        intesidadInicial = intensidad;
        tiempoMoviendose = tiempo;
        tiempoMovimientoTotal = tiempo;
    }

    private void Update()
    {
        if(tiempoMovimientoTotal > 0)
        {
            tiempoMovimientoTotal -= Time.deltaTime;
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(intesidadInicial, 0, 1 - (tiempoMoviendose / tiempoMovimientoTotal));
        }
    }

}
