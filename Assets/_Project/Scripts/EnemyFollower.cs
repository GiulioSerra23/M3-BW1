using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFollower : Enemies
{
    protected PlayerController _player;
   

    private void Awake()
    {
        _player = FindObjectOfType<PlayerController>();
    }

    public override void EnemyMovement()
    {
        if (_player == null) return ;
    
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _mover2D.Speed * Time.fixedDeltaTime);
   
    }
}