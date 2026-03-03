using UnityEditor.AdaptivePerformance.Editor;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private string currentState;
    [SerializeField] private float waitTime;

    [Header("Enemy Configurations")]
    [SerializeField] Transform[] Patrolpoints; // The array of points
    [SerializeField] private int i = 0;

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

    }

    void Patrol()
    {
        currentState = $"{States.Patroling}";
        agent.SetDestination(Patrolpoints[i].position); // ADD IENUMERATOR NEXT AFTER WAIT TIME MOVE ON TO THE NEXT POINT
    }

    void Update()
    {
        Patrol();
    }
}
