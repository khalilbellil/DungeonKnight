using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
    StateMachine.eUnitState state;
    List<Transition> list;
    Enemy enemy;

    public BaseState(Enemy e,  List<Transition> list, StateMachine.eUnitState state)
    {
        this.enemy = e;
        this.list = list;
        this.state = state;
    }

    virtual public void Enter()
    {
        Debug.Log("BASE ENTER");
    }
    
    virtual public void Update()
    {
        Debug.Log("BASE UPDATE");
    }

    virtual public void Exit()
    {
        Debug.Log("BASE EXIT");
    }

    public StateMachine.eUnitState Evaluate()
    {
        foreach (Transition t in list)
        {
            if (!t.Evluate())
                return t.toState;
        }
        return state;
    }
}
