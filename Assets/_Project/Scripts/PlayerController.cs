using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Creature
{
    [SerializeField] private float magnitude = 0.1f;
    [SerializeField] private float duration = 0.05f;

    private float _horizontal;
    private float _vertical;
    [SerializeField] private CameraShakeOnHit _shakeOnHit;

    public Vector2 Direction { get; private set; }

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        Direction = new Vector2(_horizontal, _vertical);
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

    public override void Hit()
    {
       base.Hit();
       _shakeOnHit.ShakeOnHit(duration, magnitude);
    }

    public override void Die()
    {
        base.Die();
    }
}
