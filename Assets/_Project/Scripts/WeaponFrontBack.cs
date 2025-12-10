using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFrontBack : WeaponBase
{

    protected override void Fire()
    {
        ProjectileBase bulletUp = Instantiate(projectilePrefab, transform);
        bulletUp.transform.position = transform.position;
        bulletUp.Move(Vector2.up);


        ProjectileBase bulletDown = Instantiate(projectilePrefab, transform);
        bulletDown.transform.position = transform.position;
        bulletDown.Move(Vector2.down);
    }
}
