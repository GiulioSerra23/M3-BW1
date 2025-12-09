using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFollower : Enemies
{
    public override void EnemyMovement()
    {
        if (_player != null)
        {
            Vector2 currentPos = transform.position;
            Vector2 targetPos = _player.transform.position;

            Vector2 direction = targetPos - currentPos;

            Vector2 NewPos = Vector2.MoveTowards(currentPos, targetPos, _speed * Time.deltaTime);

            transform.position = NewPos;

            if (direction.x != 0 || direction.y != 0)
            {
                _animHandler.SetDirectionalSpeed(direction);
                _animHandler.SetIsMoving(true);
            }
            else
            {
                _animHandler.SetIsMoving(false);
            }
        }
    }
}