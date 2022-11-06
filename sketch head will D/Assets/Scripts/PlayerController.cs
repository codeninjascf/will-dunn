using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 15f;

    private Rigidbody2D _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movement = moveSpeed * Input.GetAxis("Horizontal");

        Player.Turn(_rigidbody, movement);

        _rigidbody.position += movement * Time.deltaTime * Vector2.right;
    }

    void OnCollisonEnter2D()
    {
        if (_rigidbody.velocity.y <= 0)
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}