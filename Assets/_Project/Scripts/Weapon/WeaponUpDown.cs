using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpDown : Weapon
{

    protected override void Fire()
    {
        Vector2 playerPos = transform.parent.position;

        Bullet bulletUp = Instantiate(_bulletPrefab, transform);
        bulletUp.transform.position = new Vector2(playerPos.x, playerPos.y + 1);
        bulletUp.SetUp(Vector2.up);


        Bullet bulletDown = Instantiate(_bulletPrefab, transform);
        bulletDown.transform.position = new Vector2(playerPos.x, playerPos.y - 1);
        bulletDown.SetUp(Vector2.down);
    }
}
