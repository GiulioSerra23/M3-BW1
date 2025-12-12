using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLeftRight : Weapon
{

    public override void Fire()
    {
        Vector2 targetPos = transform.parent.position;

        Bullet bulletLeft = Instantiate(_bulletPrefab, transform);
        bulletLeft.transform.position = new Vector2(targetPos.x - 1, targetPos.y);
        bulletLeft.SetUp(Vector2.left);


        Bullet bulletRight = Instantiate(_bulletPrefab, transform);
        bulletRight.transform.position = new Vector2(targetPos.x + 1, targetPos.y);
        bulletRight.SetUp(Vector2.right);
    }
}
