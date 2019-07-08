using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : BaseState
{

    

    public DodgeState(Enemy e, List<Transition> list) : base(e, list, eUnitState.DODGE)
    {

    }

    public override void Enter()
    {
        
        enemy.Dodge();
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
