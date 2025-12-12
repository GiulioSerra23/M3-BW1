using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
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
}
