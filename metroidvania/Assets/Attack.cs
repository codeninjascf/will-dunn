using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerOverTime : MonoBehaviour
{
    public int damageAmount = 1;
    public bool destroyOnDamage;
    public GameObject destroyEffect;

    public void DealDamage()
    {
        PlayerHealthController.instance.DamagePlayer(damageAmount);

        if (destroyOnDamage)
        {
            if (destroyEffect != null)
            {
                Instantiate(destroyEffect, transform.position, transform.rotation);
            }
            Destroy(gameObject);
            Destroy(destroyEffect);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            DealDamage();
        }
    }



    void Update()
    {

    }
}