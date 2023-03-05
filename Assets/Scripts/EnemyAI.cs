using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;
    public float distancevalue = .2f;
    public float attackRange = 2f;
    public float chaseRange = 5f;
    public LayerMask obstacleLayer;
    public float viewAngle = 45f;

    public GameObject restartMenu;
    public GameObject pauseBtn;

    public GameObject playerDeadSFX;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    void Update()
    {
        // Check if the player is in range and in view
        GameObject player = GameObject.FindWithTag("Player");
        float playerDistance = Vector3.Distance(transform.position, player.transform.position);
        bool playerInSight = IsPlayerInSight(player);

        if (playerDistance < attackRange)
        {
            // Chase the player
            target = player.transform.position;
            agent.SetDestination(target);
            // Check for collision with the player
            
        }
        else if (playerInSight && playerDistance < chaseRange)
        {
            // Move towards the player but do not attack
            target = player.transform.position;
            agent.SetDestination(target);
        }
        else
        {
            // If the player is not in range, patrol between waypoints
            if (Vector3.Distance(transform.position, target) < distancevalue)
            {
                IterateWaypointIndex();
                UpdateDestination();
            }
        }
    }

    bool IsPlayerInSight(GameObject player)
    {
        // Check if the player is within view angle
        Vector3 directionToPlayer = player.transform.position - transform.position;
        float angle = Vector3.Angle(directionToPlayer, transform.forward);
        if (angle > viewAngle / 2)
        {
            return false;
        }

        // Check if there is an obstacle between the enemy and the player
        RaycastHit hit;
        if (Physics.Raycast(transform.position, directionToPlayer, out hit, obstacleLayer))
        {
            if (hit.transform.gameObject == player)
            {
                return true;
            }
        }
        return false;
    }

    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(playerDeadSFX, transform.position, Quaternion.identity);
            restartMenu.SetActive(true);
            pauseBtn.SetActive(false);
            Time.timeScale = 0f;
        }
    }

}
