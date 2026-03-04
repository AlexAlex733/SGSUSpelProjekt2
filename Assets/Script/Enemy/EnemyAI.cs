using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private float moveSpeed; // The movespeed of the enemy
    [SerializeField] private float currentSpeed; // the current speed of the enemy
    [SerializeField] private float sphereRange; // the sphere cast range
    [SerializeField] private float waitTime; // wait time on point
    [SerializeField] private float chaseTime; // the amount of time to chase the player before stopping
    [SerializeField] private int patrolPoint = 0; // current patrol point
    [SerializeField] private string currentState; // the state of the enemy
    [SerializeField] private bool isChasingPlayer; // if the enemy is chasing a player
    [SerializeField] private bool isEnemy; // if the enemy is an enemy of the player


    [Header("Enemy Configurations")]
    [SerializeField] Transform[] Patrolpoints; // The array of points
    [SerializeField] private Transform player;
    private RaycastHit hit; // hit info
    private Ray ray;


    [Header("Enemy Components")]
    [SerializeField] private NavMeshAgent agent; // The navmeshagent that enemy should have

    private enum States // the states of the enemy 
    {
        Patroling,
        Idling,
        Chasing,
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
        if (!isChasingPlayer)
        {
            if (Patrolpoints.Length > 0)
            {
                agent.SetDestination(Patrolpoints[patrolPoint].position);
                currentState = $"{States.Patroling}";

                if (this.transform.position == Patrolpoints[patrolPoint].position || Vector3.Distance(this.transform.position, Patrolpoints[patrolPoint].position) < 2f)
                {
                    StartCoroutine(EPatrol());
                    patrolPoint++;
                }

                if (patrolPoint == Patrolpoints.Length)
                {
                    patrolPoint = 0;
                }
            }
        }
    }

    void Detect()
    {
        ray.origin = this.transform.position;

        for (int i = 0; i < 5; i++)
        {
            ray.direction = new Vector3(this.transform.position.x, this.transform.position.y);

            Physics.Raycast(ray, out hit);
        }
    }


    void EnemyState()
    {
        if (currentSpeed <= 0)
        {
            currentState = $"{States.Idling}";
        }

        if (currentSpeed > 0)
        {
            currentState = $"{States.Patroling}";
        }
    }

    IEnumerator EPatrol()
    {
        agent.isStopped = true;
        yield return new WaitForSeconds(waitTime);
        agent.isStopped = false;
    }

    void Update()
    {
        currentSpeed = agent.velocity.magnitude;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        Patrol();
        Detect();
        EnemyState();
    }
}
