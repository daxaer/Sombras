using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarJuego : MonoBehaviour
{
    public void Guardar()
    {
        DataPersistenceManager.Instance.SaveGame();
    }
}
