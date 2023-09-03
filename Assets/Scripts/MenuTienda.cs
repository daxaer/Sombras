using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTienda : MonoBehaviour
{

    public Almas alma;
    public Estadisticas estadisticas;
    [SerializeField] private TarjetaMostrada tarjetaSlot1;

    [SerializeField] private TarjetaMostrada tarjetaSlot2;

    [SerializeField] private TarjetaMostrada tarjetaSlot3;


    // Start is called before the first frame update


    public void ModificadorCaracteristicaDelSlot1()
    {
        if(alma.CantidadAlmas > tarjetaSlot1.TarjetaEquipada.costoTarjeta)
        {
            estadisticas.ataque = estadisticas.ataque + tarjetaSlot1.TarjetaEquipada.AtaqueBonus;
            estadisticas.vidaMaxima = estadisticas.vidaMaxima + tarjetaSlot1.TarjetaEquipada.SaludBonus;
            estadisticas.velocidadPlayer = estadisticas.velocidadPlayer + tarjetaSlot1.TarjetaEquipada.VelocidadBonus;
            alma.CantidadAlmas = alma.CantidadAlmas - tarjetaSlot1.TarjetaEquipada.costoTarjeta;
        }
        
    }

    public void ModificadorCaracteristicaDelSlot2()
    {
        if (alma.CantidadAlmas > tarjetaSlot2.TarjetaEquipada.costoTarjeta)
        {
            estadisticas.ataque = estadisticas.ataque + tarjetaSlot2.TarjetaEquipada.AtaqueBonus;
            estadisticas.vidaMaxima = estadisticas.vidaMaxima + tarjetaSlot2.TarjetaEquipada.SaludBonus;
            estadisticas.velocidadPlayer = estadisticas.velocidadPlayer + tarjetaSlot2.TarjetaEquipada.VelocidadBonus;
            alma.CantidadAlmas = alma.CantidadAlmas - tarjetaSlot2.TarjetaEquipada.costoTarjeta;
        }
    }

    public void ModificadorCaracteristicaDelSlot3()
    {
        if (alma.CantidadAlmas > tarjetaSlot3.TarjetaEquipada.costoTarjeta)
        {
            estadisticas.ataque = estadisticas.ataque + tarjetaSlot3.TarjetaEquipada.AtaqueBonus;
            estadisticas.vidaMaxima = estadisticas.vidaMaxima + tarjetaSlot3.TarjetaEquipada.SaludBonus;
            estadisticas.velocidadPlayer = estadisticas.velocidadPlayer + tarjetaSlot3.TarjetaEquipada.VelocidadBonus;
            alma.CantidadAlmas = alma.CantidadAlmas - tarjetaSlot3.TarjetaEquipada.costoTarjeta;

        }
    }


}
