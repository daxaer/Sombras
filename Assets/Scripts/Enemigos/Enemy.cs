using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float _vida;
    [SerializeField] private PoolAlmas _alma;
    NavMeshAgent _agent;

    private void Start()
    {
        Destroy(this,5);
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    public void Update()
    {
        _agent.SetDestination(target.position);
    }

    public void SetTagetPlayer(Transform setTarget)
    {
        target = setTarget;
    }

    public void TakeDamage(float damage)
    {
        _vida -= damage;
        Debug.Log("recividaño");
        Debug.Log(_vida);
        if (_vida <= 0)
        {
            Debug.Log("mori");
            _alma.ActivarAlma();
            Destroy(this.gameObject);
        }
    }
    
   
}
