using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 15f;

    bool IsProvoked =false;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    
   
    float damage=20;
     

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

        FaceTarget();
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


    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRoation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRoation,Time.deltaTime * turnSpeed);
    }

    
}
