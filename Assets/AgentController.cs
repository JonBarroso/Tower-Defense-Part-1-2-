using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{

    public Transform agentDestination;
    NavMeshAgent myAgent;

    // Start is called before the first frame update
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();

        // Check if agentDestination is null
        if (agentDestination == null)
        {
            Debug.LogError("Agent destination is not assigned!");
        }
    }

    void Update()
    {
        // Check if agentDestination is null before setting destination
        if (agentDestination != null)
        {
            myAgent.destination = agentDestination.position;
        }
    }
}
