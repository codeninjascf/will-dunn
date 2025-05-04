using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D rb;

    public Vector2 moveDir;

    public GameObject impactEffect;

    public int damageAmount = 1;

    void Start()
    {
        rb.velocity = moveDir * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" )
        {
            other.GetComponent<EnemyHealthController>().DamageEnemy(damageAmount);
        }
        if (impactEffect != null)
        {
            Destroy(Instantiate(impactEffect, transform.position, Quaternion.identity),1f);
        }

        Destroy(gameObject);
    }
    // Update is called once per frame
    
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
