using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private Weapon _equippedWeapon;

    public Weapon EquippedWeapon { get => _equippedWeapon; set => _equippedWeapon = value; }

    private void Start()
    {
        Instantiate(_equippedWeapon, transform);
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        _equippedWeapon = Instantiate(newWeapon, transform);
    }

    private void Update()
    {
        _equippedWeapon = GetComponentInChildren<Weapon>();
    }
}
