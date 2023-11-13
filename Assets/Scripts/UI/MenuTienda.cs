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
            SistemaDrop.Instance.actualizar = true;
            sonidoTarjeta.Play();
            EstadisticasManager.Instance.ataque += tarjetaEquipada.ataque;
            EstadisticasManager.Instance.vidaMaxima += tarjetaEquipada.salud;
            EstadisticasManager.Instance.velocidadPlayer += tarjetaEquipada.velocidadMovimiento;
            EstadisticasManager.Instance.projectileSize += tarjetaEquipada.projectilSize;
            EstadisticasManager.Instance.velocidadeAtaque += tarjetaEquipada.velocidadAtaque;
            EstadisticasManager.Instance.roboDeVida += tarjetaEquipada.robaVida;
            EstadisticasManager.Instance.rangoIluminacion += tarjetaEquipada.rangoLampara;
            EstadisticasManager.Instance.pasivaIluminacion = tarjetaEquipada.pasivaIluminacion;
            UIManager.Instance.Almas(-tarjetaEquipada.costoTarjeta);
        }
        else
        {
            SistemaDrop.Instance.actualizar = false;
        }
    }
}
