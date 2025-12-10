using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class WeaponBase : MonoBehaviour
{
    protected string weaponName;
    protected float fireRate;
    protected float range;
    protected float lastShot;
    [SerializeField] protected GameObject projectilePrefab;

    protected abstract void Fire();

    protected bool CanShootNow()
    {
        return Time.time - lastShot > fireRate;
    }

    protected void TryToShoot()
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
