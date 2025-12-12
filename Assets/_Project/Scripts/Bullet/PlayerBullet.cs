using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
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
