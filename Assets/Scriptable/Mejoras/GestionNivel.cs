using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionNivel : MonoBehaviour
{
    [SerializeField] GameObject nivel;
    [SerializeField] TiendaMenu tiendaMenu;



    public List<GameObject> copiasNivel = new List<GameObject>();
    public int indiceActual;


   
    void Start()
    {
        for (int i = 0; i < tiendaMenu.nivelmejora; i++)
        {
            GameObject copia = Instantiate(nivel, transform);
            copiasNivel.Add(copia);
        }
    }
}
