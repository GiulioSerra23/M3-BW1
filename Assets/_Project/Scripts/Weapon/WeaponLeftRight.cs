using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLeftRight : Weapon
{

    protected override void Fire()
    {
        Vector2 playerPos = transform.parent.position;

        Bullet bulletLeft = Instantiate(_bulletPrefab, transform);
        bulletLeft.transform.position = new Vector2(playerPos.x - 1, playerPos.y);
        bulletLeft.SetUp(Vector2.left);


        Bullet bulletRight = Instantiate(_bulletPrefab, transform);
        bulletRight.transform.position = new Vector2(playerPos.x + 1, playerPos.y);
        bulletRight.SetUp(Vector2.right);
    }
}
