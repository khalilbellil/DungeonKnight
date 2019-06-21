using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public IdleState(Enemy e, List<Transition> list) : base(e, list, eUnitState.IDLE)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {

    }

    public override void Exit()
    {
        base.Exit();
    }
}
