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
    [SerializeField] private TextMeshProUGUI liveStheal;
    [SerializeField] private MejorasPermanentes[] mejorasPermanentes;
    [SerializeField] private float vida;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float ataque;
    [SerializeField] private float velocidadAtaque;
    [SerializeField] private float BalaSize;
    [SerializeField] private float roboVida;

 
    public void ActiveScriptable(ScriptableEstadisticas scriptable)
    {
        vida = scriptable.VidaMaxima + mejorasPermanentes[0].AumentoEstadisticaOtorgada;
        health.text = vida.ToString();
        velocidadMovimiento = scriptable.VelocidadDeMovimiento+ mejorasPermanentes[1].AumentoEstadisticaOtorgada;
        speed.text = velocidadMovimiento.ToString();
        ataque = scriptable.Ataque + mejorasPermanentes[2].AumentoEstadisticaOtorgada;
        attack.text = ataque.ToString();
        velocidadAtaque = scriptable.VelocidadDeAtaque + mejorasPermanentes[3].AumentoEstadisticaOtorgada;
        attackSpeed.text = velocidadAtaque.ToString();
        BalaSize = scriptable.ProjectileSize + mejorasPermanentes[4].AumentoEstadisticaOtorgada;
        projectileSize.text = BalaSize.ToString();
        roboVida = scriptable.PorcentajeRoboDeVida + mejorasPermanentes[5].AumentoEstadisticaOtorgada;
        liveStheal.text = roboVida.ToString();
    }

}
