using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyRandomMove : Enemy
{
    [SerializeField] protected float changeDirectionInterval = 2f;

    protected Vector2 _randomDirection;
    private float _timer;

    protected override void EnemyMovement()
    {
        if (_isDead) return;

        Vector2 currentPos = transform.position;

        _timer -= Time.deltaTime;
        if (_timer <= 0f)
        {
            float randomX = Random.Range(-1f, 1f);
            float randomY = Random.Range(-1f, 1f);

            _randomDirection = new Vector2(randomX, randomY).normalized;
            _timer = changeDirectionInterval;
        }

        Vector2 NewPos = currentPos + _randomDirection * _speed * Time.deltaTime;
        transform.position = NewPos;

        if (_randomDirection.x != 0 || _randomDirection.y != 0)
        {
            _animHandler.SetDirectionalSpeed(_randomDirection);
            _animHandler.SetIsMoving(true);
        }
        else
        {
            _animHandler.SetIsMoving(false);
        }
    }
}
