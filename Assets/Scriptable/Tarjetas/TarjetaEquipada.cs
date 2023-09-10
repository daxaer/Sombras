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
    public int SaludBonus;
    public int AtaqueBonus;
    public int VelocidadBonus;
    public float RangoLampara;
    public float velAtaque;
    public int RangoArma;
    public int DuracionLampara;
    public int costoTarjeta;
    public float robaVida;
    public string descripcionTarjetaEs;
    public string descripcionTarjetaEn;
    public string descripcionTarjetaJa;
    public Color colorRareza;
    [Space]
    public RarezaTarjeta RarezaTarjeta;
}
