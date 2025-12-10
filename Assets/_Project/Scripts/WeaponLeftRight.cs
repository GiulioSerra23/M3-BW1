using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLeftRight : WeaponBase
{

    protected override void Fire()
    {
        ProjectileBase bulletLeft = Instantiate(projectilePrefab, transform);
        bulletLeft.transform.position = transform.position;
        bulletLeft.Move(Vector2.left);


        ProjectileBase bulletRight = Instantiate(projectilePrefab, transform);
        bulletRight.transform.position = transform.position;
        bulletRight.Move(Vector2.right);
    }
}
