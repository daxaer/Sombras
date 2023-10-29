using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StadisticSelect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI speed;
    [SerializeField] private TextMeshProUGUI attack;
    [SerializeField] private TextMeshProUGUI attackSpeed;
    [SerializeField] private TextMeshProUGUI projectileSize;
    [SerializeField] private TextMeshProUGUI roboVida;
    [SerializeField] private MejorasPermanentes[] mejorasPermanentes;
 
    public void ActiveScriptable(ScriptableEstadisticas scriptable)
    {
        health.text = scriptable.VidaMaxima.ToString() + mejorasPermanentes[0].AumentoEstadisticaOtorgada;
        speed.text = scriptable.VelocidadDeMovimiento.ToString() + mejorasPermanentes[1].AumentoEstadisticaOtorgada;
        attack.text = scriptable.Ataque.ToString() + mejorasPermanentes[2].AumentoEstadisticaOtorgada;
        attackSpeed.text = scriptable.VelocidadDeAtaque.ToString() + mejorasPermanentes[3].AumentoEstadisticaOtorgada;
        projectileSize.text = scriptable.ProjectileSize.ToString() + mejorasPermanentes[4].AumentoEstadisticaOtorgada;
        roboVida.text = scriptable.PorcentajeRoboDeVida.ToString() + mejorasPermanentes[5].AumentoEstadisticaOtorgada;
    }

}
