using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : BaseState
{
    public DodgeState(Enemy e, List<Transition> list) : base(e, list, StateMachine.eUnitState.DODGE)
    {

    }

    public override void Enter()
    {
        Debug.Log("DODGE ENTER");
        base.Enter();
    }

    public override void Update()
    {
        Debug.Log("DODGE UPDATE");
        base.Update();
    }

    public override void Exit()
    {
        Debug.Log("DODGE EXIT");
        base.Exit();
    }
}
