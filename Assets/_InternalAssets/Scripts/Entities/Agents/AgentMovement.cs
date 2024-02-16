using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 destination;
    [SerializeField] [Range(0, 1)]
    private float speed = .5f;
    [SerializeField] [Min(.5f)]
    private float minTimeBetweenChangingDestination = 1f;
    [SerializeField] [Min(.5f)]
    private float maxTimeBetweenChangingDestination = 5f;
    private float timeUntilNewDestination = 1000f;
    private float agentHeight = 1;

    [SerializeField]
    private bool canMove = true;

    private void Start()
    {
        timeUntilNewDestination = Random.Range(minTimeBetweenChangingDestination, maxTimeBetweenChangingDestination);

        destination = new(
            Random.Range(-AgentsSpawner.Instance.AgentMaxDistance, AgentsSpawner.Instance.AgentMaxDistance),
            agentHeight,
            Random.Range(-AgentsSpawner.Instance.AgentMaxDistance, AgentsSpawner.Instance.AgentMaxDistance)
            );
    }

    private void FixedUpdate()
    {

        if (timeUntilNewDestination > 0)
        {
            timeUntilNewDestination -= Time.deltaTime;
        }
        else
        {
            destination = new(
                Random.Range(-AgentsSpawner.Instance.AgentMaxDistance, AgentsSpawner.Instance.AgentMaxDistance),
                agentHeight,
                Random.Range(-AgentsSpawner.Instance.AgentMaxDistance, AgentsSpawner.Instance.AgentMaxDistance)
                );

            timeUntilNewDestination = Random.Range(minTimeBetweenChangingDestination, maxTimeBetweenChangingDestination);
        }

        if (!canMove)
            return;

        if (Vector3.Distance(transform.position, destination) < 0.001f)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, destination, speed);
    }
}
