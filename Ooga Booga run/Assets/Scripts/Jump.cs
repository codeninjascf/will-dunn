using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jump = 4.5f;
    public float fallMultiplier = 2.5f;
    public float groundDistanceThreshold = 0.005f;

    public LayerMask whatisGround;

    public GameObject particleTrail;

    private bool _isGrounded;
    private Rigidbody _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = Physics.Raycast(_rigidbody.transform.position, Vector3.down, 
            groundDistanceThreshold, whatisGround);
        if(_isGrounded && Input.GetButton("Jump"))
        {
            _rigidbody.velocity = Vector3.up * jumpForce;
        }
        if(_rigidbody.velocity.y < 0)
        {
            _rigidbody.velocity += (fallMultiplier - 1) * Time.deltaTime * Physics.gravity;
        }
    }
}
