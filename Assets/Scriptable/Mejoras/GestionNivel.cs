using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionNivel : MonoBehaviour
{
    [SerializeField] GameObject nivel;
    [SerializeField] TiendaMenu tiendaMenu;
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < tiendaMenu.nivelmejora; i++)
        {
            Instantiate(nivel, transform);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

}
