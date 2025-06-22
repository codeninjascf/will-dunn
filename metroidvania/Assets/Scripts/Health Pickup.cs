using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int HealthAmount;
    public GameObject pickupEffect;

   private void OnTriggerEnter2D(Collider2D other)
   {
        if (other.tag == "Player")
        {
            PlayerHealthController.instance.HealPlayer(HealthAmount);

            if(pickupEffect != null)
            {
                Instantiate(pickupEffect, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
   }
   
}
