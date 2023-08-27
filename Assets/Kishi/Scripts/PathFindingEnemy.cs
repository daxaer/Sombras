using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PathFindingEnemy : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    public float vel = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.destination = target.position;
    }

    public void SetTagetPlayer(Transform setTarget)
    {
        target = setTarget;
    }
}
