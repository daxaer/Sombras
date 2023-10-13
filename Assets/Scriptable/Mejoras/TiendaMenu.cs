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

    // Start is called before the first frame update
    void Start()
    {
        
        precio = int.Parse(textoPrecio.text);
        
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public void SubiendoMejora()
    {
        GestionTienda gestionTienda = FindObjectOfType<GestionTienda>();
        gestionTienda.SeleccionarMejora(mejora, nivelmejora);
    }
   

}

