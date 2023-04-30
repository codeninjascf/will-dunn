using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnewyContwoller : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float chasingDistance = 1.5f;
    public float attackingDistance = 0.72f
    public float attackTime = 2f;

    private float _currentAttackTime;

    private Transform _player;
    private Animator animator;
    private Rigidbody _rigidbody;

    private enum EnemyState
    {
        Waiting,
        Following,
        Attacking
    }

    private EnemyState _state;
    void Start()
    {
        _player = GameManager.Player;
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
