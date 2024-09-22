using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenController : MonoBehaviour
{
    public float speed = 8;
    public float despawnTime = 3;

    private int _direction;
    // Start is called before the first frame update
    public void Initialise(int direction)
    {
        _direction = direction;

        GetComponent<Animator>().SetInteger("Direction", direction);

        Destroy(gameObject, despawnTime);
    }   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * _direction
        * speed * Vector3.right;
    }
}
