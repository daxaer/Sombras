using UnityEngine;

[CreateAssetMenu]
public class ProbTarjetas : ScriptableObject
{

    
    [System.Serializable]
    public struct Probabilidades
    {
        public ScriptableObject TarjetaEquip;
        public int probabilidadAparicion;
        
    }
    public Probabilidades[] prob;
   

}
