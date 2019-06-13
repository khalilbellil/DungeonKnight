using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eUnitState { ATTACK, MOVE, DODGE }

public class EnemySword : Enemy
{
    List<Transition.MyDelegate> list1;
    List<Transition.MyDelegate> list2;
    List<Transition.MyDelegate> list3;
    List<Transition.MyDelegate> list4;

    List<Transition> transList1;
    List<Transition> transList2;
    List<Transition> transList3;

    Dictionary<eUnitState, BaseState> stateDict;

    override public void Init()
    {
        rb = GetComponent<Rigidbody2D>();

        list1 = new List<Transition.MyDelegate>()
        {
            // attack ended
        };

        list2 = new List<Transition.MyDelegate>()
        {
            // ?
        };

        list3 = new List<Transition.MyDelegate>()
        {
            (enemy) => { return enemy.GetRange() >= Vector2.Distance(PlayerManager.Instance.player.transform.position, enemy.transform.position); }
            //(enemy) => { return enemy.GetRange() >= Vector2.Distance(new Vector2(1,1), new Vector2(9,9)); }
        };

        list4 = new List<Transition.MyDelegate>()
        {
            // Player Uses Bow / raycast it enemy, 50% chance, dodge isnt on cooldown
        };

        transList1 = new List<Transition>()
        {
            new Transition(eUnitState.ATTACK, list1, this),

        };

        transList2 = new List<Transition>()
        {
            new Transition(eUnitState.DODGE, list2, this),

        };

        transList3 = new List<Transition>()
        {
            new Transition(eUnitState.MOVE, list3, this),
            new Transition(eUnitState.MOVE, list4, this),

        };

        stateDict = new Dictionary<eUnitState, BaseState> {
            { eUnitState.ATTACK, new AttackState(this, transList1) },
            { eUnitState.DODGE, new DodgeState(this, transList2) },
            { eUnitState.MOVE, new MoveState(this,transList3) }
        };

        grid = new Grid();

        stateM = new StateMachine(eUnitState.MOVE, stateDict);
        
        Debug.Log("enemyS init");
    }

    override public void UnitUpdate()
    {
        stateM.Update();
        Debug.Log("enemyS update");
    }

    override public void UnitFixedUpdate()
    {
        stateM.FixedUpdate();
        Debug.Log("enemyS fixedupdate");
    }
    
}
