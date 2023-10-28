using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiendaMenu : MonoBehaviour
{
    public Image imagenTiendaPr;
    public Text textoPrecio;
    public Button botonComprar;
    public int nivelmejora;
    public int precio;
    public MejorasPermanentes mejora;
    public GestionNivel efecto;
    // Start is called before the first frame update
    void Start()
    {
        efecto = GetComponentInChildren<GestionNivel>();
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public void SubiendoMejora()
    {
        Debug.Log("El indice es" + efecto.indiceActual);;
        GestionTienda gestionTienda = FindObjectOfType<GestionTienda>();
        gestionTienda.SeleccionarMejora(efecto, nivelmejora,mejora);
    }
}

