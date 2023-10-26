using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaquesEnemigos : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EstadisticasManager.Instance.vidaActual -= 1;
    }
}
