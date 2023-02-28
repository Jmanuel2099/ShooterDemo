using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform[] destinations;
    [SerializeField] private float distanceToChangeDestination = 2;
    private int currentDestination = 0;
    private GameObject player;
    [SerializeField] private bool followPlayer;
    private float distanceToPlayer;
    [SerializeField] private float distanceToFollowPlayer = 10f;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.destination = destinations[0].transform.position;
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= distanceToFollowPlayer && followPlayer)
        {
            FollowPlayer();
        }else
        {
            EnemyPath();
        }   
    }

    private void EnemyPath()
    {
        navMeshAgent.destination = destinations[currentDestination].position;
        if (Vector3.Distance(transform.position, destinations[currentDestination].position) <= distanceToChangeDestination)
        {
            if(destinations[currentDestination] != destinations[destinations.Length - 1])
            {
                currentDestination ++;
            }else
            {
                currentDestination = 0;
            }
        }
    }

    private void FollowPlayer()
    {
        navMeshAgent.destination = player.transform.position;
    }
}
