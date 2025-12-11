using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMultiShot : Weapon
{

    protected override void Fire()
    {
        Vector2 playerPos = transform.parent.position;
        Vector2 dirFL = new Vector2(-1,1);
        Vector2 dirFR = new Vector2(1, 1);

        Bullet bulletF = Instantiate(_bulletPrefab, transform);
        bulletF.transform.position = new Vector2(playerPos.x, playerPos.y);
        bulletF.SetUp(Vector2.up);


        Bullet bulletFL = Instantiate(_bulletPrefab, transform);
        bulletFL.transform.position = new Vector2(playerPos.x, playerPos.y);
        bulletFL.SetUp(dirFL);

        Bullet bulletFR = Instantiate(_bulletPrefab, transform);
        bulletFR.transform.position = new Vector2(playerPos.x, playerPos.y);
        bulletFR.SetUp(dirFR);
    }
}
