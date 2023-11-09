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
    public int salud;
    public int ataque;
    public float velocidadMovimiento;
    public float rangoLampara;
    public float velocidadAtaque;
    public float projectilSize;
    public int duracionLampara;
    public int costoTarjeta;
    public float robaVida;
    public bool pasivaIluminacion;

  
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
