using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Localization.Plugins.XLIFF.V20;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EstadisticasManager : MonoBehaviour, IDataPersiistence
{

    //Almas
    public int almasMax;

    //Estadisticas iniciales
    public float velocidadPlayer;
    public float vidaMaxima;
    public float vidaActual;
    public float ataque;
    public float projectileSize;
    public float velocidadeAtaque;
    public float roboDeVida;
    public float duracionLamparas;
    public float rangoIluminacion;
    public GameObject bala;
    public bool ataqueMele;
    [SerializeField] private MejorasPermanentes[] mejorasPermanentes;

    //Pasivas
    public bool pasivaIluminacion;

    [SerializeField] private ScriptableEstadisticas personajeSeleccionado;
    public static EstadisticasManager Instance;

    private void Awake()
    {
        almasMax = 0;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    public void LoadData(GameData _data)
    {
        Debug.Log(_data.rondaActual + "rondaActual");
        personajeSeleccionado = _data.estadisticas;
        if(_data.rondaActual > 0)
        {
            bala = personajeSeleccionado.Bala;
            ataqueMele = personajeSeleccionado.AtaqueMele;
            vidaMaxima = _data.vidaMaxima;
            velocidadPlayer = _data.velocidadPlayer;
            vidaActual = _data.vidaActual;
            ataque = _data.ataque;
            projectileSize = _data.ProjectileSize;
            velocidadeAtaque = _data.velocidadeAtaque;
            roboDeVida = _data.roboDeVida;
            duracionLamparas = _data.duracionLamparas;
            rangoIluminacion = _data.rangoIluminacion;

            //Pasivas
            pasivaIluminacion = _data.iluminarEnemigos;
        }
        else
        {
            vidaMaxima = personajeSeleccionado.VidaMaxima + mejorasPermanentes[0].AumentoEstadisticaOtorgada;
            velocidadPlayer = personajeSeleccionado.VelocidadDeMovimiento + mejorasPermanentes[1].AumentoEstadisticaOtorgada; ;
            vidaActual = personajeSeleccionado.vidaActual + mejorasPermanentes[0].AumentoEstadisticaOtorgada; ;
            ataque = personajeSeleccionado.Ataque + mejorasPermanentes[2].AumentoEstadisticaOtorgada; ;
            projectileSize = personajeSeleccionado.ProjectileSize + mejorasPermanentes[3].AumentoEstadisticaOtorgada; ;
            velocidadeAtaque = personajeSeleccionado.VelocidadDeAtaque + mejorasPermanentes[4].AumentoEstadisticaOtorgada; ;
            roboDeVida = personajeSeleccionado.PorcentajeRoboDeVida + mejorasPermanentes[5].AumentoEstadisticaOtorgada; ;
            duracionLamparas = personajeSeleccionado.TiempoIluminacion;
            rangoIluminacion = personajeSeleccionado.RangoIluminacion;
            bala = personajeSeleccionado.Bala;
            ataqueMele = personajeSeleccionado.AtaqueMele;

            //Pasivas
            pasivaIluminacion = personajeSeleccionado.Iluminar;
        }
    }
    public void ActualizarVida()
    {
        vidaActual = vidaMaxima;
        MusicManager.Instance.PlayAudioPool(SOUNDTYPE.GET_HEALTH, Player.Instance.transform);
    }
    public void saveGame()
    {
        if(EstadisticasManager.Instance.vidaActual <= 0)
        {
            Player.Instance.dead = true;
            DataPersistenceManager.Instance.SaveGame();

        }
        else
        {
            DataPersistenceManager.Instance.SaveGame();
        }
    }

    public void SaveData(ref GameData _data)
    {
        if(Player.Instance.dead == true)
        {
            _data.rondaActual = 0;
            Debug.Log(_data.rondaActual + "Moriste");
        }
        else
        {
            if (Timer.Instance.rondaActual == 5)
            {
                _data.rondaActual = 0;

                Debug.Log(_data.rondaActual + "Ganaste");
            }
            else
            {
                _data.rondaActual = Timer.Instance.rondaActual;
                Debug.Log(_data.rondaActual + "Y la vida Continua");
            }
        }
        _data.AlmasMax += almasMax;
        _data.vidaMaxima = vidaMaxima;
        _data.velocidadPlayer = velocidadPlayer;
        _data.vidaActual = vidaActual;
        _data.ataque = ataque;
        _data.ProjectileSize = projectileSize;
        _data.velocidadeAtaque = velocidadeAtaque;
        _data.roboDeVida = roboDeVida;
        _data.duracionLamparas = duracionLamparas;
        _data.rangoIluminacion = rangoIluminacion;

        //Pasivas
        _data.iluminarEnemigos = pasivaIluminacion;
    }
}
