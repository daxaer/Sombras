using AllIn1SpriteShader;
using Pathfinding;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    [SerializeField] protected float _lifeIncrease = 1f;
    [SerializeField] protected bool iluminar;
    [SerializeField] protected Animator animation_Ojo;
    [SerializeField] protected Animator animation_Cuerpo;
    [SerializeField] protected Animator animation_Brillo;

    [SerializeField] protected float _vida;
    [SerializeField] protected int _damage;
    [SerializeField] protected float _vidaMin;
    [SerializeField] protected float _vidaMax;
    [SerializeField] protected float _speedMin;
    [SerializeField] protected float _speedMax;
    [SerializeField] protected float _damageMin;
    [SerializeField] protected float _damageMax;
    [SerializeField] protected Renderer material;

    [SerializeField] protected AIPath aiPath;
    [SerializeField] protected bool RecibirDaño;

    void Start()
    {
        _vida = (int)Mathf.Floor(AmountDifficult(Timer.Instance.rondaActual, _vidaMin, _vidaMax));
        aiPath.maxSpeed = AmountDifficult(Timer.Instance.rondaActual, _speedMin, _speedMax);
        _damage = (int)Mathf.Floor(AmountDifficult(Timer.Instance.rondaActual, _damageMin, _damageMax));
    }
    private void Update()
    {
        if (!Timer.Instance._stoptimer)
        {
            DeactivateEnemies();
        }
    }
    public void DeactivateEnemies()
    {
        SpawnManager.Instance.RestarCurrentEnemy();
        gameObject.SetActive(false); //nos apagamos para seguir en el pool
    }

    public void Desactivar() // esto sera mi nuevo "Destruir"
    {
        SpawnManager.Instance.RestarCurrentEnemy();
        SpawnManager.Instance.SpawnAlmas(gameObject.transform);
        gameObject.SetActive(false); //nos apagamos para seguir en el pool
    }

    public virtual void Atacar(){}

    public virtual void Cargando(){}

    private void OnEnable()
    {

    }

    public void Activarluz()
    {
        material.material.EnableKeyword("OUTBASE_ON");
        CancelInvoke("DesactivarLuz");
        Invoke(nameof(DesactivarLuz), 5f);
        //shader.
    }

    public void DesactivarLuz()
    {
        material.material.DisableKeyword("OUTBASE_ON");
        gameObject.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Enemigos";
    }

    public float AmountDifficult(int _round, float _estadisticMin, float _estadisticMax)
    {
        int roundMax = 15;
        float estadistic = _estadisticMin + (_estadisticMax - _estadisticMin) * Mathf.Pow((_round - 1) / (roundMax - 1), 3);
        return estadistic;
    }
    public void TakeDamage(float damage)
    {
        if(RecibirDaño)
        {
            RecibirDaño = false;
            _vida -= damage;
            Debug.Log(_vida);
            if (_vida <= 0)
            {
                Invoke(nameof(Desactivar), 0f);
            }
            else
            {
                StartCoroutine("damageAnule");
            }
        }
    }
    IEnumerator damageAnule()
    {
        yield return new WaitForSeconds(EstadisticasManager.Instance.velocidadeAtaque - 0.05f);
        RecibirDaño = true;
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Desactivar));
    }
}
