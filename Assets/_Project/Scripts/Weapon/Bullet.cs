using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected int _damage;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _lifeSpan;

    private Rigidbody2D _rb;

    protected void Start()
    {
        Destroy(gameObject, _lifeSpan);
    }

    public void SetUp(Vector2 direction)
    {
        if (_rb == null) _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = direction * _lifeSpan;
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        var lifeController = collision.collider.GetComponent<LifeController>();

        if (collision.collider.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.Hit(_damage);

            if (lifeController.Hp <= 0)
            {
                enemy.Die();
            }
        }
    }
}
