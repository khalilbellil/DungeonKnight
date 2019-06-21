using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum eUnitState { ATTACK, MOVE, DODGE }



public class Boss : Enemy
{

    

    List<Transition.MyDelegate> list1;
    List<Transition.MyDelegate> list2;
    List<Transition.MyDelegate> list3;

    List<Transition> transList1;
    List<Transition> transList2;
    List<Transition> transList3;

    Dictionary<eUnitState, BaseState> stateDict;

    override public void Init()
    {
        base.Init();

        target = PlayerManager.Instance.player.transform;

        list1 = new List<Transition.MyDelegate>()
        {
            (enemy) => { return true; }
        };

        list2 = new List<Transition.MyDelegate>()
        {
            (enemy) => { return true; }
        };

        list3 = new List<Transition.MyDelegate>()
        {
            (enemy) => { return this.GetRange() <= Vector2.Distance(PlayerManager.Instance.player.transform.position, this.transform.position); }
        };

        transList1 = new List<Transition>()
        {
            new Transition(eUnitState.DODGE, list1, this)

        };

        transList2 = new List<Transition>()
        {
            new Transition(eUnitState.MOVE, list2, this)

        };

        transList3 = new List<Transition>()
        {
            new Transition(eUnitState.ATTACKKSLIME, list3, this)

        };

        stateDict = new Dictionary<eUnitState, BaseState> {
            { eUnitState.ATTACKKSLIME, new AttackKSlimeState(this, transList1) },
            { eUnitState.DODGE, new DodgeState(this, transList2) },
            { eUnitState.MOVE, new MoveState(this,transList3) }
        };

        grid = new Grid();

        stateM = new StateMachine(eUnitState.MOVE, stateDict);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.CompareTag("Player"))
        {
            PlayerManager.Instance.player.TakeDamage(10);
        }

    }

    override public void Death()
    {
        //Debug.Log("enemy isDead");
        base.Death();
        EnemyManager.Instance.KillAll();
    }



}
