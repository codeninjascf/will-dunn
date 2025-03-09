using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private bool canDoubleJump;

    
    public Rigidbody2D rb;

    public Transform groundPoint;
    private bool onGround;
    public LayerMask whatIsGround;

    public BulletController shotToFire;
    public Transform shotPoint;

    public float moveSpeed = 8;
    public float jumpForce = 20;

    public Animator anim;
    
    public float dashSpeed, dashTime;
    private float dashCounter;

    public SpriteRenderer theSR, afterImage;
    public float afterImageLifetime, timeBetweenAfterImages;
    private float afterImageCounter;
    public Color afterImageColor;

    public float waitAfterDashing;
    private float dashRechargeCounter;

    public void Update()
    {
        if(dashRechargeCounter > 0)
        {
            dashRechargeCounter -= Time.deltaTime;
        }

        if(Input.GetButtonDown("Fire2"))
        {
            dashCounter = dashTime;

            ShowAfterImage();
        }
           dashRechargeCounter = waitAfterDashing;

        if(dashCounter > 0)
        {
            dashCounter = dashCounter - Time.deltaTime;

            rb.velocity = new Vector2(dashSpeed * transform.localScale.x, rb.velocity.y);

            afterImageCounter -= Time.deltaTime;
            if(afterImageCounter <= 0)
            {
                ShowAfterImage();
            }
        }
        else
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);

            if (rb.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (rb.velocity.x > 0)
            {
                transform.localScale = Vector3.one;
            }
        }

        

        if (Input.GetButtonDown("Jump") && (onGround || canDoubleJump))
        {
            if (onGround)
            {
                canDoubleJump = true;
            }
            else
            {
                canDoubleJump = false;
            }

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }
        

        onGround = Physics2D.OverlapCircle(groundPoint.position, .2f, whatIsGround);

        anim.SetBool("isOnGround", onGround);
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(shotToFire, shotPoint.position, shotPoint.rotation).moveDir = new Vector2(transform.localScale.x, 0f);
            anim.SetTrigger("shotFired");
        }


    }

    public void ShowAfterImage()
    {
        SpriteRenderer image = Instantiate(afterImage, transform.position, transform.rotation);
        image.sprite = theSR.sprite;
        image.transform.localScale = transform.localScale;
        image.color = afterImage.color;

        Destroy(image.gameObject,afterImageLifetime);

        afterImageCounter = timeBetweenAfterImages;
    }
}
