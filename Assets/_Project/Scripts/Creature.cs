using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    private string Name;
    private LifeController lifeController;
    private TopDownMover2D topDownMover2D;


    public Creature(string Name, LifeController lifeController, TopDownMover2D topDownMover2D)
    {
        this.Name = Name;
        this.lifeController = lifeController;
        this.topDownMover2D = topDownMover2D;
    }
    private void Awake()
    {

        lifeController = GetComponent<LifeController>();
        topDownMover2D = GetComponent<TopDownMover2D>();
    }
}