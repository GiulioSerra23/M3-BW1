using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponMultiShot : Weapon
{
    private PlayerController _player;

    protected void Awake()
    {
        _player = GetComponentInParent<PlayerController>();
    }

    public override void Fire()
    {
        Vector2 mainDir = _player.LastNonZeroDir;
        Vector2 leftDir = Quaternion.Euler(0, 0, -20f) * mainDir;
        Vector2 rightDir = Quaternion.Euler(0, 0, +20f) * mainDir;

        float offSet = 0.5f;

        Bullet bulletF = Instantiate(_bulletPrefab, transform);
        bulletF.transform.position = (Vector2)transform.parent.position + mainDir * offSet;
        bulletF.SetUp(mainDir);

        Bullet bulletFL = Instantiate(_bulletPrefab, transform);
        bulletFL.transform.position = (Vector2)transform.parent.position + leftDir * offSet;
        bulletFL.SetUp(leftDir);

        Bullet bulletFR = Instantiate(_bulletPrefab, transform);
        bulletFR.transform.position = (Vector2)transform.parent.position + rightDir * offSet;
        bulletFR.SetUp(rightDir);
    }
}
