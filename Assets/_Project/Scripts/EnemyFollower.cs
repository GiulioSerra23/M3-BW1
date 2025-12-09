using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFollower : Enemies
{
    public override void EnemyMovement()
    {
        if (_player == null) return;

        Vector2 currentPos = transform.position;
        Vector2 targetPos = _player.transform.position;

        Vector2 direction = (targetPos - currentPos);

        Vector2 NewPos = Vector2.MoveTowards(currentPos, targetPos, _speed * Time.deltaTime);

        transform.position = NewPos;
    }
}