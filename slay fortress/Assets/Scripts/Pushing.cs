using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushing : MonoBehaviour
{
    public float pushPower = 2f;
    private bool _pushing;
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (_pushing)
        {
            Invoke("StopPushing", 0.1f);
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic || hit.moveDirection.y < -0.3)
        {
            {
                return;
            }
            

            _pushing = true;

            Vector3 pushDirection;

            if (Mathf.Abs(hit.moveDirection.x) > Mathf.Abs(hit.moveDirection.z)) ;
            {
                pushDirection = new Vector3(hit.moveDirection.x, 0, 0);
            }
            if (Mathf.Abs(hit.moveDirection.x) > Mathf.Abs(hit.moveDirection.z)) ;
            {
                pushDirection = new Vector3(0, 0, hit.moveDirection.z);
            }
            body.velocity = pushDirection * pushPower;

            _animator.SetBool("isPushing", true);
        }
    }
    
    void StopPushing()
    {
        _animator.SetBool("isPushing", false);
        _pushing = false;

        body.velocity = pushDirection * pushPower;
    }

    


    
}
