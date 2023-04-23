using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

    }
    private int Direction
    {
        get
        {
            if (GameManager.GameOver)
            {
                return 0;
            }
            if (GameManager.Player.transform.position.x < transform.position.x)
            {
                return -1;
            }

        }   

            

        set
        {

        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
