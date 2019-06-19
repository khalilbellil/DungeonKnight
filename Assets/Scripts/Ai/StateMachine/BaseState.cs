using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
    public eUnitState state;
    public List<Transition> list;
    public Enemy enemy;

    public BaseState(Enemy e,  List<Transition> list, eUnitState state)
    {
        this.enemy = e;
        this.list = list;
        this.state = state;
    }

    virtual public void Enter()
    {
        //Debug.Log("BASE ENTER");
    }
    
    virtual public void Update()
    {
        //Debug.Log("BASE UPDATE");
    }

    virtual public void FixedUpdate()
    {
        //Debug.Log("BASE FIXEDUPDATE");
    }

    virtual public void Exit()
    {
        //Debug.Log("BASE EXIT");
    }

    public eUnitState Evaluate()
    {
        foreach (Transition t in list)
        {
            if (t.Evluate())
                return t.toState;
        }
        return state;
    }
}
