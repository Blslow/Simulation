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
    }

    private void Terminate()
    {
        AgentsSpawner.CurrentAgentsCount--;
    }
}
