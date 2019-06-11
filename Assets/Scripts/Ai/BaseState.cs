using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
    public enum eUnitState{ATTACK,MOVE,DODGE}

    public BaseState(BaseUnit unit,  List<Transition> list)
    {

    }

    virtual public void Enter()
    {
        
    }
    
    virtual public void Update()
    {
        
    }

    virtual public void Exit()
    {

    }

    public eUnitState Evaluate()
    {
        return eUnitState.ATTACK;
    }
}
