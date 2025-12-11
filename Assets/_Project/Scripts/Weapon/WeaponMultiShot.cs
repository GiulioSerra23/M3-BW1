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
        bulletF.transform.position = transform.parent.position;
        bulletF.SetUp(Vector2.up);

        Bullet bulletFL = Instantiate(_bulletPrefab, transform);
        bulletFL.transform.position = transform.parent.position;
        bulletFL.SetUp(dirFL);

        Bullet bulletFR = Instantiate(_bulletPrefab, transform);
        bulletFR.transform.position = transform.parent.position;
        bulletFR.SetUp(dirFR);
    }
}
