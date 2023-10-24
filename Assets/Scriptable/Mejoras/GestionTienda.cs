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
            mejora.costeMejoraActual = mejora.costeInicial + (mejora.nivelActual * mejora.aumentoPrecio);
            GameObject tiendaDelMenu = Instantiate(menuDeTienda, transform);
            tiendaDelMenu.GetComponentInChildren<GestionNivel>().mejora = mejora.nivelActual;
            TiendaMenu tiendaMenu = tiendaDelMenu.GetComponent<TiendaMenu>();
            tiendaMenu.imagenTiendaPr.sprite = mejora.imagenMejora;
            if (mejora.nivel == mejora.nivelActual)
            {
                tiendaMenu.textoPrecio.text = "Nivel Max";
            }
            else
            {
                tiendaMenu.textoPrecio.text = mejora.costeMejoraActual.ToString();
            }
            tiendaMenu.nivelmejora = mejora.nivel;
            tiendaMenu.mejora = mejora;
        }
        //Eliminar tambien despues
        textoAlmasMejora.text = AlmasPrueba.ToString();
    }

    public void SeleccionarMejora(GestionNivel gestionNivel, int nivelMax, MejorasPermanentes mejoras)
    {
        //Calculo momentaneo
        if (gestionNivel.copiasNivel != null && gestionNivel.copiasNivel.Count > 0 && AlmasPrueba > mejoras.costeMejoraActual)
        {
            if (gestionNivel.indiceActual >= 0 && gestionNivel.indiceActual < gestionNivel.copiasNivel.Count)
            {
                Image imagen = gestionNivel.copiasNivel[gestionNivel.indiceActual].GetComponent<Image>();

                if (imagen != null)
                {
                    imagen.color = Color.white;
                    AlmasPrueba = AlmasPrueba - mejoras.costeMejoraActual;
                    mejoras.EstadisticaOtorgada = mejoras.EstadisticaOtorgada + mejoras.aumentoEstadistica;
                    mejoras.costeMejoraActual = mejoras.costeMejoraActual + mejoras.aumentoPrecio;
                    
                }
                gestionNivel.indiceActual++;
                mejoras.nivelActual = gestionNivel.indiceActual;
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
            if (mejora.nivel == mejora.nivelActual)
            {
                tiendaMenu.textoPrecio.text = "Nivel Max";
            }
            else
            {
                tiendaMenu.textoPrecio.text = mejora.costeMejoraActual.ToString();
            }

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
