using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Transform target;
    NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    public void Update()
    {
        _agent.SetDestination(target.position);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        _health.TakeDamage(1);
    }

    public void SetTagetPlayer(Transform setTarget, Health setHealth)
    {
        target = setTarget;
        _health = setHealth;
    }
}
