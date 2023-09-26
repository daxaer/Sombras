using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionTienda : MonoBehaviour
{
    [SerializeField] List<MejorasPermanentes> mejoraPermanente;
    [SerializeField] GameObject menuDeTienda;
    public Text textoAlmasMejora;
    public int AlmasPrueba;

    void Start()
    {
        for (int i = 0; i < mejoraPermanente.Count; i++)
        {
            var mejora = mejoraPermanente[i];
            GameObject tiendaDelMenu = Instantiate(menuDeTienda, transform);
            TiendaMenu tiendaMenu = tiendaDelMenu.GetComponent<TiendaMenu>();

            tiendaMenu.imagenTiendaPr.sprite = mejora.imagenMejora;
            tiendaMenu.textoPrecio.text = mejora.costeMejora.ToString();
            tiendaMenu.nivelmejora = mejora.nivel;
            tiendaMenu.mejora = mejora;
            int indiceActual = i; 

           
            //tiendaMenu.botonComprar.onClick.AddListener(() => SeleccionarMejora(mejora, indiceActual));
        }
       
        //Eliminar tambien despues
        textoAlmasMejora.text = AlmasPrueba.ToString();
    }

    public void SeleccionarMejora(MejorasPermanentes mejora, int indice)
    {
        AlmasPrueba = AlmasPrueba - mejora.costeMejora;
        Debug.Log("Mejora seleccionada: " + mejora.costeMejora + " (Índice: " + indice + ")");
        ActualizarMejoras();
    }

    public void ActualizarMejoras()
    {
        textoAlmasMejora.text = AlmasPrueba.ToString();
    }
}
