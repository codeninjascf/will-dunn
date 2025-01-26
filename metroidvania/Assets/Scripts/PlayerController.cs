using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody2D rb;

    public Transform groundPoint;
    private bool onGround;
    public LayerMask whatIsGround;

    public float moveSpeed = 8;
    public float jumpForce = 20;

    public void Update()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        onGround = Physics2D.OverlapCircle(groundPoint.position, .2f, whatIsGround);
    }

}
