using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Creature : MonoBehaviour
{ 
    [SerializeField] protected string _name;

    protected LifeController _lifeController;
    protected TopDownMover2D _mover2D;
    protected AnimationParamHandler _animHandler;

    protected bool _isHit;
    protected bool _isDead;

    protected virtual void Awake()
    {
        _lifeController = GetComponent<LifeController>();
        _mover2D = GetComponent<TopDownMover2D>();
        _animHandler = GetComponent<AnimationParamHandler>();
    }

    public virtual void Hit()
    {
        _isHit = true;
        _animHandler.SetIsHit();
    }

    public virtual void Die()
    {
        if (_lifeController.Hp <= 0)
        {
            _isDead = true;
            _animHandler.SetIsDead();
            GetComponent<Collider2D>().enabled = false;
        }
    }
}