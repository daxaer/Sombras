using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Tarjeta : ScriptableObject
{
    public Sprite imagenTarjeta;
    public string IdTarjeta;

    public string[] nombreTarjeta;

    



    public string NombreTarjetas(int idioma)
    {

        if (idioma >= 0 && idioma < nombreTarjeta.Length)
        {
            return nombreTarjeta[idioma];
        }
        else
        {
            return "No existe el idioma";
        }
    }
}
