using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivar : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("Apagar",1f);
    }

    private void Apagar() 
    { 
        gameObject.SetActive(false);
    }    
}
