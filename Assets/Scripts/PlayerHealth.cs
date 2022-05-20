using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    

    public void DamagePlayer(float damage)
    {
        hitPoints -= damage;
        Debug.Log("Enemy is damaging Player and Remaining Health is: "+hitPoints);

        if (hitPoints <= 0)
        {
            Debug.Log("PLayer is Dead");
        }
    }
}
