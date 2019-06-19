﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : BaseState
{

    public MoveState(Enemy e, List<Transition> list) : base(e, list, eUnitState.MOVE)
    {
    }

    public override void Enter()
    {
        
        //Debug.Log("MOVE ENTER");
        base.Enter();
    }

    public override void Update()
    {
        //Debug.Log("MOVE UPDATE");
        base.Update();
    }

    public override void FixedUpdate()
    {
        enemy.Move(enemy.target);
        //Debug.Log("MOVE FIXEDUPDATE");
    }

    public override void Exit()
    {
        enemy.rb.velocity = new Vector2();
        //Debug.Log("MOVE EXIT");
        base.Exit();
    }
}
