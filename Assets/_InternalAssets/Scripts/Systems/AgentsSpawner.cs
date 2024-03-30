using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class AgentsSpawner : Singleton<AgentsSpawner>
{
    [SerializeField]
    private GameObject agentPrefab;

    [Space]
    [Header("How many agents should initially spawn")]
    [SerializeField] [Min(0)]
    private int minStartAgentsCount = 3;
    [SerializeField] [Min(0)]
    private int maxStartAgentsCount = 5;

    [Space]
    [Header("How often should new agent be spawned")]
    [SerializeField] [Min(.01f)]
    private float minSpawnTime = 2;
    [SerializeField] [Min(.01f)]
    private float maxSpawnTime = 6;

    [Space]
    [SerializeField] [Range(0, 100)]
    [Description("Controls how far away from center of map agent can walk away and spawn")]
    private float agentMaxDistance = 10;
    [SerializeField] [Range(1, 5)]
    private float agentsSpawnHeight = 3;

    [Space]
    [SerializeField]
    private int maxAgentsCount = 30;

    [SerializeField]
    private float timeUntilNextSpawn = 1000;

    private int currentAgentsCount = 0;
    //public static int CurrentAgentsCount = 0;

    public float AgentMaxDistance { get => agentMaxDistance; }
    public int CurrentAgentsCount { get => currentAgentsCount; set => currentAgentsCount = value; }

    private void Start()
    {
        int startAgentsCount = Random.Range(minStartAgentsCount, maxStartAgentsCount);

        for (int i = 0; i < startAgentsCount; i++)
        {
            SpawnAgent();
        }

        timeUntilNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

    private void Update()
    {
        if (CurrentAgentsCount >= maxAgentsCount)
            return;

        if (timeUntilNextSpawn > 0)
        {
            timeUntilNextSpawn -= Time.deltaTime;
        }
        else
        {
            SpawnAgent();
            timeUntilNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }

    public void SpawnAgent()
    {
        Vector3 spawnPosition = new(Random.Range(-agentMaxDistance, agentMaxDistance), agentsSpawnHeight, Random.Range(-agentMaxDistance, agentMaxDistance));

        ObjectPoolManager.SpawnObject(agentPrefab, spawnPosition, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(new Vector3(0, 0, 0), new Vector3(agentMaxDistance * 2, 0, agentMaxDistance * 2));
    }
}
