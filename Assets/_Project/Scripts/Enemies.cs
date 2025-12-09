using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies: Creature
{
    [SerializeField] protected float _speed;

    protected PlayerController _player;
    protected bool _playerInTrigger;
    

    protected override void Awake()
    {
        base.Awake();
        _player = FindObjectOfType<PlayerController>();
    }

    public virtual void EnemyMovement()
    {

    }

    private void FixedUpdate()
    {
        if (_playerInTrigger)
        {
            EnemyMovement();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out var player))
        {
            if (player != null)
            {
                _playerInTrigger = true;
            }
        }
    }
}
