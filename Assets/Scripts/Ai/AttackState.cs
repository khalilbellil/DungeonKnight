using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    public AttackState(Enemy e, List<Transition> list ) : base(e, list, StateMachine.eUnitState.ATTACK)
    {
        
    }

    public override void Enter()
    {
        Debug.Log("ATTACK ENTER");
        base.Enter();
    }

    public override void Update()
    {
        Debug.Log("ATTACK UPDATE");
        base.Update();
    }

    public override void Exit()
    {
        Debug.Log("ATTACK EXIT");
        base.Exit();
    }
}
