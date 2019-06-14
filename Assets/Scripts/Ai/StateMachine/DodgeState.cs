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
        Debug.Log("DODGE ENTER");
        base.Enter();
    }

    public override void Update()
    {
        Debug.Log("DODGE UPDATE");
        base.Update();
    }

    public override void FixedUpdate()
    {
        Debug.Log("DODGE FIXEDUPDATE");
    }

    public override void Exit()
    {
        Debug.Log("DODGE EXIT");
        base.Exit();
    }
}
