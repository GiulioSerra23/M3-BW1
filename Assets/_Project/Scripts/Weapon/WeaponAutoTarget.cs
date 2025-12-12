using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAutoTarget : Weapon
{
    private EnemyManager _enemyManager;

    private void Awake()
    {
        _enemyManager = FindObjectOfType<EnemyManager>();
    }

    private GameObject FindNearestEnemy()
    {
        GameObject nearestEnemy = null;

        float minDistance = _fireRange;

        foreach (var enemy in _enemyManager.Enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);

            if (distance <= minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy.gameObject;
            }
        }

        return nearestEnemy;
    }

    public override void Fire()
    {
        GameObject nearestEnemy = FindNearestEnemy();
        if (nearestEnemy == null) return;

        Vector2 direction = (nearestEnemy.transform.position - transform.position).normalized;

        Bullet clonedBullet = Instantiate(_bulletPrefab, transform);
        clonedBullet.transform.position = transform.parent.position;
        clonedBullet.SetUp(direction);
    }
}
