using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies: Creature
{
    [SerializeField] protected float _speed;

    protected PlayerController _player;
    protected EnemyManager _enemyManager;
    protected bool _playerInTrigger;
    

    protected override void Awake()
    {
        base.Awake();
        _player = FindObjectOfType<PlayerController>();
        _enemyManager = FindObjectOfType<EnemyManager>();
        _enemyManager.AddEnemy(this);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<PlayerController>(out var player))
        {
            player.Hit();
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

    public override void Die()
    {
        base.Die();
        _enemyManager.RemoveEnemy(this);
    }
}
