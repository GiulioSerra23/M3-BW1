using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Bullet projectilePrefab;
    [SerializeField] protected float fireRate;
    [SerializeField] protected float range;

    protected float lastShot;

    protected abstract void Fire();

    private bool CanShootNow()
    {
        return Time.time - lastShot > fireRate;
    }

    private void TryToShoot()
    {
        if(CanShootNow())
        {
            lastShot = Time.time;   
            Fire();
        }
    }

    private void Update()
    {
        TryToShoot();
    }
}
