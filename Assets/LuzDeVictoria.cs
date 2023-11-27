using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class LuzDeVictoria : MonoBehaviour
{
    Light2D luz;
    [SerializeField] private float intensidadFinal;
    [SerializeField] private float duracion;
    public static LuzDeVictoria Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }
    private void Start()
    {
        luz = GetComponent<Light2D>();
    }

    public IEnumerator Luz()
    {
        float aumentar = 0f;
        float intensidadInicial = luz.intensity;  // Guardar la intensidad inicial de la luz

        while (aumentar <= duracion)
        {
            // Calcular la nueva intensidad utilizando Mathf.Lerp
            float nuevaIntensidad = Mathf.Lerp(intensidadInicial, intensidadFinal, aumentar / duracion);

            // Asignar la nueva intensidad a la luz
            luz.intensity = nuevaIntensidad;

            aumentar += Time.deltaTime;
            yield return null;
        }
    }

}
