using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private string currentState;

    [Header("Enemy Configurations")]
    [SerializeField] Transform[] Patrolpoints; // The array of points


    [Header("Enemy Components")]
    [SerializeField] private NavMeshAgent agent; // The navmeshagent that enemy should have

    private enum States
    {
        Patroling,
        Idling,
        Attacking
    }


    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Get the navmesh from the enemy

        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = moveSpeed;

        currentState = $"{States.Idling}";
    }

    void Patrol()
    {

    }


}
