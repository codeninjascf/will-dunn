using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public float blastRange;
    public LayerMask whatIsDestructible;

    public float timeToExplode;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeToExplode -= Time.deltaTime;
        if(timeToExplode <= 0)
        {
            if(explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            Destroy(gameObject);

            Collider2D[] objectsToRemove = Physics2D.OverlapCircleAll(transform.position, blastRange, whatIsDestructible);

            if(objectsToRemove.Length > 0)
            {
                foreach(Collider2D col in objectsToRemove)
                {
                    Destroy(col.gameObject);
                }
            }
        }
    }
}
