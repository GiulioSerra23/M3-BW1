using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: Creature
{
    
    [SerializeField] protected float _speed;
    [SerializeField] protected int _damage;
    [SerializeField] protected List<Pickup> _pickupWeapons; 

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

    protected virtual void EnemyMovement()
    {

    }

    public override void Die()
    {
        base.Die();
        _enemyManager.RemoveEnemy(this);
        PickUpWeapons();
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
            player.Hit(_damage);

            if (lifeController.Hp <= 0)
            {
                player.Die();
            }
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

    private void PickUpWeapons()
    {
        int _randomNum = Random.Range(0, 101);

        if (_randomNum <= 5)
        {
            Instantiate(_pickupWeapons[0], transform.position, Quaternion.identity);
        }
        else if (_randomNum > 5 && _randomNum <= 15)
        {
            Instantiate(_pickupWeapons[1], transform.position, Quaternion.identity);
        }
        else if (_randomNum > 15 && _randomNum <= 30)
        {
            Instantiate(_pickupWeapons[2], transform.position, Quaternion.identity);
        }
        else if (_randomNum > 30 && _randomNum <= 50)
        {

            if(Random.value < 0.5)
            {
                Instantiate(_pickupWeapons[3], transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_pickupWeapons[4], transform.position, Quaternion.identity);
            }

        }
    }
}
