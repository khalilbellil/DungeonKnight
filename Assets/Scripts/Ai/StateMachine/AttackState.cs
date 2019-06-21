using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    bool isBow;
    float timeStartDrawing;
    float percentBowDrawn { get { return Mathf.Clamp01((Time.time - timeStartDrawing) / Bow.maxDrawingTime); } set {  } }

    public AttackState(Enemy e, List<Transition> list) : base(e, list, eUnitState.ATTACK)
    {
        isBow = (e.GetType() == typeof(EnemyBow));
    }

    public override void Enter()
    {

        enemy.weaponList[0].WeaponUpdate(Time.deltaTime, false, PlayerManager.Instance.player.transform.position - enemy.transform.position, enemy.transform.position);
        if(isBow)
            timeStartDrawing = Time.time;
        //Debug.Log("ATTACK ENTER");
        base.Enter();
    }


    public override void Update()
    {
        
        
        if (isBow)
        {
            if(percentBowDrawn == 1)
            {
                enemy.weaponList[0].WeaponUpdate(Time.deltaTime, true, PlayerManager.Instance.player.transform.position - enemy.transform.position, enemy.transform.position);
                timeStartDrawing = Time.time;
                percentBowDrawn = 0;
                Debug.Log("");
            }
            else
            {
                enemy.weaponList[0].WeaponUpdate(Time.deltaTime, false, PlayerManager.Instance.player.transform.position - enemy.transform.position, enemy.transform.position);
                Debug.Log("");
            }
        }
        else
        {
            enemy.weaponList[0].WeaponUpdate(Time.deltaTime, true, PlayerManager.Instance.player.transform.position - enemy.transform.position, enemy.transform.position);
        }
        
        

        base.Update();
    }

    public override void FixedUpdate()
    {
        //Debug.Log("ATTACK FIXEDUPDATE");
    }

    public override void Exit()
    {
        enemy.weaponList[0].WeaponUpdate(Time.deltaTime, false, PlayerManager.Instance.player.transform.position - enemy.transform.position, enemy.transform.position);
        base.Exit();
    }
}
