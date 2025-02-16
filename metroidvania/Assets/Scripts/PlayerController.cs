using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public Transform groundPoint;
    private bool onGround;
    public LayerMask whatIsGround;

    public float moveSpeed = 8;
    public float jumpForce = 20;

    public Animator anim;

    public void Update()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if(rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if(rb.velocity.x > 0)
        {
            transform.localScale = Vector3.one;
        }

        onGround = Physics2D.OverlapCircle(groundPoint.position, .2f, whatIsGround);

        anim.SetBool("isOnGround", onGround);
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }

}
