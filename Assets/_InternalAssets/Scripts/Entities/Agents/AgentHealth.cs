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
    [SerializeField]
    private UnityEvent OnHit;

    private void OnEnable()
    {
        healthPoints = maxHealthPoints;
    }
    public void GetHit()
    {
        OnHit.Invoke();
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
            Rigidbody pushedBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 direction = pushedBody.transform.position - transform.position;
            pushedBody.AddForce(direction.normalized * 100, ForceMode.Force);
        }
    }
}
