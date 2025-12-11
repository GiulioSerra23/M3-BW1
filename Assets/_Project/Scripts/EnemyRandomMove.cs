using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyRandomMove : Enemy
{
    [SerializeField] protected float changeDirectionInterval = 2f;

    protected Vector2 _randomDirectionL;
    private float _timer;

    protected override void Awake()
    {
        base.Awake();
        NewDirection();
    }

    protected override void EnemyMovement()
    {
        if (!_isDead)
        {
            Vector2 currentPos = transform.position;
            Vector2 NewPos = currentPos + _randomDirectionL * _speed * Time.deltaTime;
            transform.position = NewPos;
            _timer += Time.deltaTime;
            if (_timer >= changeDirectionInterval)
            {
                NewDirection();
                _timer = 0f;
            }
            if (_randomDirectionL.x != 0 || _randomDirectionL.y != 0)
            {
                _animHandler.SetDirectionalSpeed(_randomDirectionL);
                _animHandler.SetIsMoving(true);
            }
            else
            {
                _animHandler.SetIsMoving(false);
            }
        }
    }

    protected void NewDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        _randomDirectionL = new Vector2(randomX, randomY).normalized;
    }
}
