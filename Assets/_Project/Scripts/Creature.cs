using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour

{ 
    [SerializeField] protected string _name;


    protected LifeController _lifeController;
    protected TopDownMover2D _mover2D;
    protected AnimationParamHandler _animHandler;


    private void Awake()
    {

        _lifeController = GetComponent<LifeController>();
        _mover2D = GetComponent<TopDownMover2D>();
        _animHandler = GetComponent<AnimationParamHandler>();
    }
}