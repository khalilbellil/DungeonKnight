using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackKSlimeState : BaseState
{
    bool isBow = true;
    float timeStartDrawing = 0;
    float percentBowDrawn { get { return Mathf.Clamp01((Time.time - timeStartDrawing) / 10); } set { } }

    public AttackKSlimeState(Enemy e, List<Transition> list) : base(e, list, eUnitState.ATTACKKSLIME)
    {

    }

    public override void Enter()
    {
        
    }


    public override void Update()
    {
        Debug.Log("charge for attack" + percentBowDrawn);
        if (percentBowDrawn == 1)
        {
            enemy.rb.velocity = new Vector2();
            enemy.LaunchSlime();
            isBow = true;
            timeStartDrawing = Time.time;
            Debug.Log("enemy summon");
        }
    }

    public override void FixedUpdate()
    {
    }

    public override void Exit()
    {
        
        //base.Exit();
    }
}
