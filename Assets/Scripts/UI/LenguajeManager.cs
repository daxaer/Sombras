using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public  class LenguajeManager : MonoBehaviour
{
    private LenguajeManager _instance;
    [SerializeField] Lenguage currentLenguage;

    private void Awake()
    {
        _instance = this;
    }

    public static LenguajeManager GetInstance()
    {
        return _instance;
    }
    // Start is called before the first frame update
    
}

public enum Lenguage{
    es,
    en,
    jap
}
