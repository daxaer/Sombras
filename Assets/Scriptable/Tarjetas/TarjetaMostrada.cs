using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class TarjetaMostrada : MonoBehaviour
{

    public TarjetaEquipada TarjetaEquipada;
    [SerializeField] Text nombreTarjeta;
    [SerializeField] Text descripcionTarjeta;
    [SerializeField] Text costeTarjeta;
    [SerializeField] Image imagenTarjeta;
    [SerializeField] Image marcoTarjeta;

    
    // Start is called before the first frame update
    void Start()
    {
        Actualizar();
    }

    private void Update()
    {
        
    }

    public void Actualizar()
    {
        nombreTarjeta.text = TarjetaEquipada.nombreTarjetaEs;
        descripcionTarjeta.text = TarjetaEquipada.descripcionTarjetaEs;
        costeTarjeta.text = TarjetaEquipada.costoTarjeta.ToString();
        marcoTarjeta.color = TarjetaEquipada.colorRareza;
        imagenTarjeta.sprite = TarjetaEquipada.imagenTarjeta;
    }
    
}
