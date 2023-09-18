using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuTienda : MonoBehaviour
{

    public Almas alma;

    public AudioSource sonidoTarjeta;

    [SerializeField] private Estadisticas estadisticas;
    
    [SerializeField] private TarjetaMostrada tarjetaSlot1;

    [SerializeField] private TarjetaMostrada tarjetaSlot2;

    [SerializeField] private TarjetaMostrada tarjetaSlot3;


    // Start is called before the first frame update


    public void ModificadorCaracteristicaDelSlot(int slot)
    {
        if (slot < 1 || slot > 3)
        {
            return;
        }

        TarjetaEquipada tarjetaEquipada = null;
        

        switch (slot)
        {
            case 1:
                tarjetaEquipada = tarjetaSlot1.TarjetaEquipada;
                break;
            case 2:
               
                tarjetaEquipada = tarjetaSlot2.TarjetaEquipada;
                break;
            case 3:
               
                tarjetaEquipada = tarjetaSlot3.TarjetaEquipada;
                break;
        }

        if (alma.CantidadAlmas >= tarjetaEquipada.costoTarjeta)
        {
            sonidoTarjeta.Play();
            estadisticas.ataque += tarjetaEquipada.AtaqueBonus;
            estadisticas.vidaMaxima += tarjetaEquipada.SaludBonus;
            estadisticas.velocidadPlayer += tarjetaEquipada.VelocidadBonus;
            estadisticas.rango += tarjetaEquipada.RangoArma;
            estadisticas.VelocidadeAtaque += tarjetaEquipada.velAtaque;
            estadisticas.roboDeVida += tarjetaEquipada.robaVida;
            estadisticas.iluminarEnemigo += tarjetaEquipada.RangoLampara;
            alma.CantidadAlmas -= tarjetaEquipada.costoTarjeta;
            alma.ActualizarAlmas();
        }
       


    }
}
