using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]Transform target;
    [SerializeField] float damage = 40f;

    private void Start()
    {


    }


    public void AttactHitEvent()
    {
        if (target == null) return;
        Debug.Log("Bang!!  Enemy is hitting" + target.name);
    }
}
