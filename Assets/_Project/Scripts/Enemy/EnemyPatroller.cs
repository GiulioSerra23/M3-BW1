using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroller : Enemy
{
    [SerializeField] private Transform[] _patrolPoints;

    private int _currentPatrolIndex = 0;

    protected override void EnemyMovement()
    {
        if (_isDead) return;
        if (_patrolPoints.Length == 0) return;

        Vector2 currentPos = transform.position;
        Vector2 targetPos = _patrolPoints[_currentPatrolIndex].position;

        Vector2 direction = targetPos - currentPos;

        Vector2 newPos = Vector2.MoveTowards(
            currentPos,
            targetPos,
            _speed * Time.deltaTime
        );

        transform.position = newPos;

        if (direction.sqrMagnitude > 0.01f)
        {
            _animHandler.SetDirectionalSpeed(direction);
            _animHandler.SetIsMoving(true);
        }
        else
        {
            _animHandler.SetIsMoving(false);

            _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Length;
        }
    }

    public override void Die()
    {
        base.Die();
        Instantiate(_pickUpPrefab, transform.position, Quaternion.identity);
    }
}