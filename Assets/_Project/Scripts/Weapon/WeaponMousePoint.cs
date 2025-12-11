using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMousePoint : Weapon
{
    private Camera _cam;

    private void Awake()
    {
        _cam = Camera.main;
    }

    protected override void Fire()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = -_cam.transform.position.z;

        Vector3 mouseWorldPos = _cam.ScreenToWorldPoint(mouseScreenPos);

        Vector3 direction = (mouseWorldPos - transform.parent.position).normalized;

        Bullet clonedBullet = Instantiate(_bulletPrefab, transform);
        clonedBullet.transform.position = transform.parent.position;
        clonedBullet.SetUp(direction);
    }
}
