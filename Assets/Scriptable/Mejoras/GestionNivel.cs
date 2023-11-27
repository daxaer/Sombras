using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionNivel : MonoBehaviour
{
    [SerializeField] GameObject nivel;
    [SerializeField] TiendaMenu tiendaMenu;

    public List<GameObject> copiasNivel = new List<GameObject>();
    public int indiceActual;
    public int mejora;

    public void Start()
    {
        for (int i = 0; i < tiendaMenu.nivelmejora; i++)
        {
            GameObject copia1 = Instantiate(nivel, transform);
            if (mejora > i)
            {
                indiceActual = mejora;
                copia1.GetComponent<Image>().color = Color.white;
            }
            copiasNivel.Add(copia1);
        }
    }
}
