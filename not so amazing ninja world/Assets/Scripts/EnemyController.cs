using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public float maxHealth = 1;
    public float currentHealth = 1;
    public float jumpForce = 7f;

    public AudioSource jumpAudio;

    public float damage = 1;

    private Rigidbody2D  rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
         if(other.gameObject.CompareTag("Shuriken"))
        {
            currentHealth -= damage;
            Debug.Log("Hit the enemy!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            DestroyGameObject();
        }
    }

     void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
