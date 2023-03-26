using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    private Animator _animator;
    private Jump _jump;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _jump = GetComponent<Jump>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_jump.GetIsGrounded())
        {
            _animator.SetBool("isRunning", true);
            _animator.SetBool("isRunning", false);
        }

        else
        {
            _animator.SetBool("isRunning", false);
            _animator.SetBool("isRunning", true);
        }
    }
}