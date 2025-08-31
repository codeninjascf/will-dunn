using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int totalHealth = 3;
    public GameObject deathEffect;
    

    public void DamageEnemy(int damageAmount)
    {
        totalHealth -= damageAmount;

        if(totalHealth <= 0)
        {
            if(deathEffect != null)
            {
                Destroy(Instantiate(deathEffect,transform.position, transform.rotation),1f);
            }
            Destroy(gameObject);
            
        }
    }
}
