using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentsSpawner : MonoBehaviour
{
    [SerializeField]
    private int minStartAgentsCount = 3;
    [SerializeField]
    private int maxStartAgentsCount = 5;
    [SerializeField]
    private GameObject agentPrefab;

}
