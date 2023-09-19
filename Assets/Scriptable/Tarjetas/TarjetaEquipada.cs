using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum RarezaTarjeta
{
   Comun,
   PocoComun,
   Rara,
   Epica,
   Legendaria
}

[CreateAssetMenu]
public class TarjetaEquipada : Tarjeta
{
    public string[] descripcionDeTarjeta;
    public int SaludBonus;
    public int AtaqueBonus;
    public int VelocidadBonus;
    public float RangoLampara;
    public float velAtaque;
    public float RangoArma;
    public int DuracionLampara;
    public int costoTarjeta;
    public float robaVida;

  
    public Color colorRareza;
    [Space]
    public RarezaTarjeta RarezaTarjeta;


    public string DescripcionTarjetas(int idioma)
    {

        if (idioma >= 0 && idioma < descripcionDeTarjeta.Length)
        {
            return descripcionDeTarjeta[idioma];
        }
        else
        {
            return "No existe el idioma";
        }
    }
}
