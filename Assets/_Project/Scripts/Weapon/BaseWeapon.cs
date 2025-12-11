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
    protected override void Fire()
    {
        
        Vector2 playerPos = transform.parent.position;

        Bullet bullet = Instantiate(_bulletPrefab, transform);
        bullet.transform.position = new Vector2(playerPos.x, playerPos.y);
        
        if(_playerController.Direction == Vector2.zero)
        {
            bullet.SetUp(_playerController.LastNonZeroDir);
        }
        else
        {
            bullet.SetUp(_playerController.Direction);
        }
            
    }
}
