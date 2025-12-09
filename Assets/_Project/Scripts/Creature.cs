using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{ 
    [SerializeField] protected string _name;

    protected LifeController _lifeController;
    protected TopDownMover2D _mover2D;
    protected AnimationParamHandler _animHandler;

    public Creature(string name, LifeController lifeController, TopDownMover2D mover2D, AnimationParamHandler animHandler)
    {
        _name = name;
        _lifeController = lifeController;
        _mover2D = mover2D;
        _animHandler = animHandler;
    }

    private void Awake()
    {
        _lifeController = GetComponent<LifeController>();
        _mover2D = GetComponent<TopDownMover2D>();
        _animHandler = GetComponent<AnimationParamHandler>();
    }
    private void Awake()
    {

        lifeController = GetComponent<LifeController>();
        topDownMover2D = GetComponent<TopDownMover2D>();
    }
}