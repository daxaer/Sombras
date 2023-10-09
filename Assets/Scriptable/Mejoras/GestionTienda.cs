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
        }
        //Eliminar tambien despues
        textoAlmasMejora.text = AlmasPrueba.ToString();
    }

    public void SeleccionarMejora(GestionNivel efecto, int indice, MejorasPermanentes mejoras)
    {
        //Calculo momentaneo
        int calculo = 750;
        if (efecto.copiasNivel != null && efecto.copiasNivel.Count > 0 && AlmasPrueba > mejoras.costeMejora)
        {
            if (efecto.indiceActual >= 0 && efecto.indiceActual < efecto.copiasNivel.Count)
            {
                Image imagen = efecto.copiasNivel[efecto.indiceActual].GetComponent<Image>();

                if (imagen != null)
                {
                    imagen.color = Color.white;
                    AlmasPrueba = AlmasPrueba - mejoras.costeMejora;
                    mejoras.costeMejora = mejoras.costeMejora + calculo;
                    
                }
                efecto.indiceActual++;
            }
        }
        tienda();
        textoAlmasMejora.text = AlmasPrueba.ToString();
    }

    public void tienda()
    {
        for (int i = 0; i < mejoraPermanente.Count; i++)
        {
            var mejora = mejoraPermanente[i];
            GameObject tiendaDelMenu;
            if (transform.childCount > i)
            {
                tiendaDelMenu = transform.GetChild(i).gameObject;
            }
            else
            {
                tiendaDelMenu = Instantiate(menuDeTienda, transform);
            }

            TiendaMenu tiendaMenu = tiendaDelMenu.GetComponent<TiendaMenu>();

            tiendaMenu.imagenTiendaPr.sprite = mejora.imagenMejora;
            tiendaMenu.textoPrecio.text = mejora.costeMejora.ToString();
            tiendaMenu.nivelmejora = mejora.nivel;
            tiendaMenu.mejora = mejora;
        }
        while (transform.childCount > mejoraPermanente.Count)
        {
            DestroyImmediate(transform.GetChild(transform.childCount - 1).gameObject);
        }
        textoAlmasMejora.text = AlmasPrueba.ToString();
    }
}
