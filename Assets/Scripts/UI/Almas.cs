using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Almas : MonoBehaviour
{
    [SerializeField] private Text textoAlmas;
    public int CantidadAlmas;

    // Start is called before the first frame update
    void Start()
    {
        textoAlmas = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        textoAlmas.text = CantidadAlmas.ToString();
    }
   
   
}
