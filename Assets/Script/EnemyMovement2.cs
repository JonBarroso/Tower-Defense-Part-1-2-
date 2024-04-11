using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement2 : MonoBehaviour
{
    private NavMeshAgent agent;
    private Enemy enemy;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemy = GetComponent<Enemy>();

        // Set initial destination
        agent.SetDestination(Waypoints.points[0].position);
    }

    void Update()
    {
        // Check if agent has reached its destination
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            GetNextWaypoint();
        }

        // Reset speed
        enemy.speed = enemy.startSpeed;
    }

    void GetNextWaypoint()
    {
        // Increment waypoint index
        int nextWaypointIndex = Random.Range(0, Waypoints.points.Length);
        Vector3 nextWaypoint = Waypoints.points[nextWaypointIndex].position;

        // Set new destination
        agent.SetDestination(nextWaypoint);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the enemy has reached the end of the path
        if (other.CompareTag("End"))
        {
            EndPath();
        }
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
