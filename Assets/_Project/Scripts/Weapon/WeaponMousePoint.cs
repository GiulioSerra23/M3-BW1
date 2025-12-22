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

    public override void Fire()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = -_cam.transform.position.z;

        Vector3 mouseWorldPos = _cam.ScreenToWorldPoint(mouseScreenPos);

        Vector3 direction = (mouseWorldPos - transform.parent.position).normalized;

        float offSet = 0.5f;

        Bullet clonedBullet = Instantiate(_bulletPrefab, transform);
        clonedBullet.transform.position = (Vector3)transform.parent.position + direction * offSet;
        clonedBullet.SetUp(direction);
    }
}
