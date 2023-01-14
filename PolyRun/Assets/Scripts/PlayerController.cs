using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 25f;

    private bool _isGrounded;
    private Rigidbody2D _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();   
    }

  
    void Update()
    {
        if (Input.GetMouseButton(0) && _isGrounded)
            _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
     void OnCollisionEnter2D(Collision2D other)
     {
      if (other.gameObject.CompareTag("Ground"))
      {
            if (PlayerCollisions.CollidedWithSide(gameObject, other.gameObject, PlayerCollisions.Side.Bottom))
            {
                _isGrounded = true;
            }
            else if (other.gameObject.CompareTag("Enemy"))
            {
                GameManager.EndGame();
            }
            else
            {
                GameManager.EndGame();
            }
            
      }
     }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
     if (other.gameObject.CompareTag("Coin"))
        {
            GameManager.Score += 25;
            other.gameObject.SetActive(false);
        }
    }


}
