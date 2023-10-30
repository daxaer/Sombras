using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DesactivarAudio : MonoBehaviour
{
    public float tiempo;
    private void OnEnable()
    {
        Invoke("Apagar",tiempo);
    }
    public void Apagar()
    {
        gameObject.SetActive(false);
    }
}
