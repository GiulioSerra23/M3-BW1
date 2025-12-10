using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    Rigidbody2D Projectile;
    protected int damage;
    protected float speed;
    protected float lifeTime;

    protected void Awake()
    {
        Projectile = GetComponent<Rigidbody2D>();
        Destroy(gameObject,lifeTime);
    }
    public void Move(Vector2 direction)
    {
        Projectile.velocity = direction * speed;
    }
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        LifeController lifeController = GetComponent<LifeController>();
        if (collision.collider.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.Hit(damage);
            if (lifeController.Hp <= 0)
            {
                enemy.Die();
            }
        }
    }
}
