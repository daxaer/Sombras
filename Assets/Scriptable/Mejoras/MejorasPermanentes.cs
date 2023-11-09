using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu]
public class MejorasPermanentes : ScriptableObject
{
    public Sprite imagenMejora;
    public int costeMejoraActual;
    public int costeInicial;
    public int nivel;
    public int nivelActual;
    public int AumentroPrecio;
    public float AumentoEstadistica;
    public float AumentoEstadisticaOtorgada;
}
