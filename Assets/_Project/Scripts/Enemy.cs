using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: Creature
{
    [SerializeField] protected float _speed;
    [SerializeField] protected int _damage;

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

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        var lifeController = collision.collider.GetComponent<LifeController>();

        if (collision.collider.TryGetComponent<PlayerController>(out var player))
        {
            lifeController.TakeDamage(_damage);
            player.Hit();
            player.Die();
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
