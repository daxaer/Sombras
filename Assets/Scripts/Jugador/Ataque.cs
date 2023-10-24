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
    [SerializeField] private bool _canAttack = true; //se puede atacar?
    [SerializeField] private Animator animatorOjos;
    [SerializeField] private Animator animatorCuerpo;
    [SerializeField] private Animator animatorArma;
    private void Start()
    {

    }
    public void Update()
    {
        //if (Input.GetKey(KeyCode.Space)) 
        //{
            Atacar();
        //}
    }

<<<<<<< HEAD
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
=======
>>>>>>> parent of fd69355 (apuntado)
    public void Atacar()
    {
        if(_canAttack)
        {
            StartCoroutine(SpeedAtack());
            Debug.Log("atacando");
            _canAttack = false;
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
        Instantiate(EstadisticasManager.Instance.bala, spawnAtaque.position, spawnAtaque.rotation);
        //GameObject temp = SpawnManager.Instance.SpawnAtaque(spawnAtaque);
        //Projectil proj = temp.GetComponent<Projectil>();
    }
}
