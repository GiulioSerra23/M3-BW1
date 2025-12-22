using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Creature
{
    [SerializeField] private CameraShakeOnHit _shakeOnHit;

    private float _horizontal;
    private float _vertical;

    public bool IsDead { get => _isDead; }

    public Vector2 Direction { get; private set; }

    public Vector2 LastNonZeroDir { get; private set; } = new Vector2(0, -1);

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        Direction = new Vector2(_horizontal, _vertical);
        
        if(Direction != Vector2.zero)
        {
            LastNonZeroDir = Direction;
        }

        _mover2D.SetAndNormalizeInput(Direction);

        if (_horizontal != 0 || _vertical != 0)
        {
            _animHandler.SetDirectionalSpeed(Direction);
            _animHandler.SetIsMoving(true);
        }
        else
        {
            _animHandler.SetIsMoving(false);
        }
    }

    public override void Hit(int damage)
    {
        if (_isDead) return;

        base.Hit(damage);
        _shakeOnHit.ShakeOnHit();
    }

    public override void Die()
    {
        base.Die();
    }
}
