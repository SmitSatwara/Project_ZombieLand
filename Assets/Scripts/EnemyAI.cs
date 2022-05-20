using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;

    bool IsProvoked =false;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (IsProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget < chaseRange)
        {
            IsProvoked = true;
        }
        else if (distanceToTarget > chaseRange)
        {
            IsProvoked = false;
        }

    }

    private void EngageTarget()
    {
        if (distanceToTarget >=navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if ( distanceToTarget<navMeshAgent.stoppingDistance)
        {
            AttactTarget();
        }
    }

    private void AttactTarget()
    {
        GetComponent<Animator>().SetBool("attact", true);
        Debug.Log(name+" is Attacking"+target.name);
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attact", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    
}
