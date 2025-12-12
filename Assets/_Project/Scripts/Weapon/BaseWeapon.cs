using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : Weapon
{
    private PlayerController _playerController;

    protected void Awake()
    {
        _playerController = GetComponentInParent<PlayerController>();
    }
    public override void Fire()
    {
        Vector2 playerPos = transform.parent.position;

        Bullet bullet = Instantiate(_bulletPrefab, transform);
        bullet.transform.position = transform.parent.position;
        bullet.SetUp(_playerController.LastNonZeroDir);            
    }
}
