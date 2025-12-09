using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform _target;
    protected Rigidbody2D _rigidbody2D;
    protected TopDownMover2D _mover;

    private void Awake()
    {
        _mover = GetComponent<TopDownMover2D>();
    }
}
