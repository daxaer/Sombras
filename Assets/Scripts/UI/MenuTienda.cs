using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuTienda : MonoBehaviour
{
    public AudioSource sonidoTarjeta;

    //[SerializeField] private Estadisticas estadisticas;
    
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

        if (UIManager.Instance.GetAlmas() >= tarjetaEquipada.costoTarjeta)
        {
            sonidoTarjeta.Play();
            EstadisticasManager.Instance.ataque += tarjetaEquipada.AtaqueBonus;
            EstadisticasManager.Instance.vidaMaxima += tarjetaEquipada.SaludBonus;
            EstadisticasManager.Instance.velocidadPlayer += tarjetaEquipada.VelocidadBonus;
            EstadisticasManager.Instance.rango += tarjetaEquipada.RangoArma;
            EstadisticasManager.Instance.velocidadeAtaque += tarjetaEquipada.velAtaque;
            EstadisticasManager.Instance.roboDeVida += tarjetaEquipada.robaVida;
            EstadisticasManager.Instance.rangoIluminacion += tarjetaEquipada.RangoLampara;
            UIManager.Instance.Almas(-tarjetaEquipada.costoTarjeta);
        }
    }
}
