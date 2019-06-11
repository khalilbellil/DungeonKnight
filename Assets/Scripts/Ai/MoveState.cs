using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : BaseState
{
    public MoveState(Enemy e, List<Transition> list) : base(e, list, StateMachine.eUnitState.MOVE)
    {

    }

    public override void Enter()
    {
        Debug.Log("MOVE ENTER");
        base.Enter();
    }

    public override void Update()
    {
        Debug.Log("MOVE UPDATE");
        base.Update();
    }

    public override void Exit()
    {
        Debug.Log("MOVE EXIT");
        base.Exit();
    }
}
