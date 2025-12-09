using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationParamHandler : MonoBehaviour
{
    [SerializeField] private string _hSpeedName = "hSpeed";
    [SerializeField] private string _vSpeedName = "vSpeed";
    [SerializeField] private string _isMoving = "isMoving";
    [SerializeField] private string _isDeadName = "isDead";
    [SerializeField] private string _isHasWeaponName = "hasWeapon";
    [SerializeField] private string _isHitName = "isHit";
    [SerializeField] private string _isAttackingName = "isAttacking";

    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    public void SetDirectionalSpeed(Vector2 speed)
    {
        SetHorizontalSpeed(speed.x);
        SetVerticalSpeed(speed.y);
    }

    public void SetHorizontalSpeed(float speed)
    {
        _anim.SetFloat(_hSpeedName, speed);
    }

    public void SetVerticalSpeed(float speed)
    {
        _anim.SetFloat(_vSpeedName, speed);
    }

    public void SetIsMoving(bool isMoving)
    {
        _anim.SetBool(_isMoving, isMoving);
    }

    public void SetIsDead(bool isDead)
    {
        _anim.SetBool(_isDeadName, isDead);
    }
    public void SetHasWeapon(bool hasWeapon)
    {
        _anim.SetBool(_isHasWeaponName, hasWeapon);
    }

    public void SetIsHit()
    {
        _anim.SetTrigger(_isHitName);
    }

    public void SetIsAttacking()
    {
        _anim.SetTrigger(_isAttackingName);
    }
}