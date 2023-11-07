using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActualizarAlmas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI almas;
    [SerializeField] private TextMeshProUGUI total;
    // Start is called before the first frame update
    private void OnEnable()
    {
        almas.text = EstadisticasManager.Instance.almasGuardadas.ToString() ;
        total.text = EstadisticasManager.Instance.almasMax.ToString();
    }
}
