using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentHealth : MonoBehaviour
{
    [SerializeField]
    private int healthPoints = 3;
    [SerializeField]
    private int maxHealthPoints = 3;

    [SerializeField]
    private UnityEvent OnDeath;

    private void OnEnable()
    {
        healthPoints = maxHealthPoints;
    }
    public void GetHit()
    {
        healthPoints--;

        if (healthPoints <= 0)
        {
            OnDeath.Invoke();
            ObjectPoolManager.ReturnObjectToPool(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<AgentHealth>())
        {
            GetHit();
        }
    }
}
