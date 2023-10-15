using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Ataque : MonoBehaviour
{
    //public Estadisticas estadisticas;
    public AudioSource sonidoAtaque;
    [SerializeField] private Transform spawnAtaque;

    public KeyCode attackKey = KeyCode.Space; //tecla
    [SerializeField] private bool _canAttack; //se puede atacar?
    [SerializeField] private bool atacando; 

    [SerializeField] private Animator animatorOjos;
    [SerializeField] private Animator animatorCuerpo;
    [SerializeField] private Animator animatorArma;
    private PlayerInput playerInput;
    private void Start()
    {
        atacando = false;
        _canAttack = true;
        playerInput = GetComponent<PlayerInput>();
        playerInput.actions["Atacar"].performed += Pressed;
        playerInput.actions["Atacar"].canceled += UnPreseed;
    }

    private void Update()
    {
        if (atacando)
        {
            Atacar();
        }
    }
    public void Pressed(InputAction.CallbackContext context)
    {
        atacando = true;
    }
    public void UnPreseed(InputAction.CallbackContext context)
    {
        atacando = false;
    }
    public void Atacar()
    {
        if(_canAttack && atacando)
        {
            _canAttack = false;
            StartCoroutine(SpeedAtack());
            //MusicManager.Instance.PlayAudio(SOUNDTYPE.HIT_ENEMY, transform.position);
            animatorArma.SetTrigger("Atacar");
            animatorCuerpo.SetTrigger("Atacar");
            animatorOjos.SetTrigger("Atacar");
        }
    }

    private IEnumerator SpeedAtack()
    {
        yield return new WaitForSeconds(EstadisticasManager.Instance.velocidadeAtaque);
        _canAttack = true;
    }

    public void SpawnAtaque()
    {
        GameObject temp = SpawnManager.Instance.SpawnAtaque(spawnAtaque);
        Projectil proj = temp.GetComponent<Projectil>();
    }
    private void OnDestroy()
    {
        playerInput.actions["Atacar"].performed -= Pressed;
        playerInput.actions["Atacar"].canceled -= UnPreseed;
    }
}
