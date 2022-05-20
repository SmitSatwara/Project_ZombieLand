using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 1f;

    private void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }
    public void AttactHitEvent()
    {
        if (target == null) return;
        target.DamagePlayer(damage);
        Debug.Log("Bang!!  Enemy is hitting " + target.name);
    }
}
