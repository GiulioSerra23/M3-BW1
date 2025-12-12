using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpDown : Weapon
{

    public override void Fire()
    {
        float offSet = 0.5f;

        Bullet bulletUp = Instantiate(_bulletPrefab, transform);
        bulletUp.transform.position = (Vector2)transform.parent.position + Vector2.up * offSet;
        bulletUp.SetUp(Vector2.up);


        Bullet bulletDown = Instantiate(_bulletPrefab, transform);
        bulletDown.transform.position = (Vector2)transform.parent.position + Vector2.down * offSet;
        bulletDown.SetUp(Vector2.down);
    }
}
