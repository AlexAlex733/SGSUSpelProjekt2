using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

// Made By Rami
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private float moveSpeed; // The movespeed of the enemy
    [SerializeField] private float currentSpeed; // the current speed of the enemy
    [SerializeField] private float chaseRange; // the chase range
    [SerializeField] private float attackRange; // the attack range
    [SerializeField] private float waitTime; // wait time on point
    [SerializeField] private float chaseTime; // the amount of time to chase the player before stopping
    [SerializeField] private int patrolPoint = 0; // current patrol point
    [SerializeField] private States currentState; // the state of the enemy
    [SerializeField] private bool isChasingPlayer; // this is to make the agent aka enemy not follow patrol route when it is chasing the player
    [SerializeField] private bool isAttackingPlayer; // this is to check if the enemy is attacking


    [Header("Enemy Configurations")]
    [SerializeField] Transform[] patrolpoints; // The array of points
    [SerializeField] private Transform player;
    [SerializeField] private Transform noPlayer;
    private RaycastHit hit; // hit info
    private Ray ray; // the ray info

    private bool isWaiting = false; // this is for not triggering EPatrol 100b times


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

        try // try do it so it doesnt crash the game
        {
            player = GameObject.FindWithTag("Player").transform;
        }
        catch (System.Exception ex)
        {
            noPlayer.position = new Vector3(0f, 0f, 0f);
            player = noPlayer;
            Debug.Log($"Error: {ex} and has been set to 0,0,0");
        }
    }

    void Patrol() // this is for patroling
    {
        if (isChasingPlayer || isAttackingPlayer) // a check to make sure it doesnt patrol when attack or chase
            return;

        currentState = States.Patroling; // set the state
        agent.SetDestination(patrolpoints[patrolPoint].transform.position); // we want to set destination to the point

        if (Vector3.Distance(this.transform.position, patrolpoints[patrolPoint].transform.position) < 1f) // check if the agent or enemy is close to the point by 1 and then call IEnumerator for waiting
        {
            if (!isWaiting) // not waiting then go to nexts
            {
                StartCoroutine(EPatrol());
            }
        }
    }

    void Chase()  // chase function
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < chaseRange) // check the distance 
        {
            isChasingPlayer = true;
            agent.SetDestination(player.transform.position - new Vector3(2,2,2));
            currentState = States.Chasing;
            Debug.Log("Player Has Been Detected!");
        }
        else
        {
            isChasingPlayer = false;
        }

        if (Vector3.Distance(this.transform.position, player.transform.position) < attackRange) // check the distance
        {
            isChasingPlayer = false;
            isAttackingPlayer = true;
            agent.SetDestination(player.transform.position);
            Attack();
        }
        else
        {
            isAttackingPlayer = false;
        }
    }

    void Attack() // attack
    {
        currentState = States.Attacking;
        Debug.Log("Attacking Player");
        SceneManager.LoadScene("DeathScene");
    }

    IEnumerator EPatrol()
    {
        isWaiting = true;
        agent.isStopped = true;
        currentState = States.Idling;

        yield return new WaitForSeconds(waitTime);

        patrolPoint++;

        if (patrolPoint == patrolpoints.Length)
        {
            patrolPoint = 0;
        }

        agent.isStopped = false;
        isWaiting = false;
    }

    void Update()
    {
        currentSpeed = agent.velocity.magnitude;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        Patrol();
        Chase();
    }
}
