using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnInitialize;
    [SerializeField]
    private UnityEvent OnDestroy;
    [SerializeField]
    private string agentName = "-";
    public string AgentName { get => agentName; }

    private void OnEnable()
    {
        OnInitialize.Invoke();
        Initialize();
    }

    private void OnDisable()
    {
        OnDestroy.Invoke();
        Terminate();
    }

    private void Initialize()
    {
        AgentsSpawner.CurrentAgentsCount++;
        agentName = "Agent" + Random.Range(1, 1000);
    }

    private void Terminate()
    {
        AgentsSpawner.CurrentAgentsCount--;
    }
}
