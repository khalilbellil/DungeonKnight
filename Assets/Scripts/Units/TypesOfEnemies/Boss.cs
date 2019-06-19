using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum eUnitState { ATTACK, MOVE, DODGE }

public class Boss : Enemy
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
        base.Init();

        target = PlayerManager.Instance.player.transform;

        list1 = new List<Transition.MyDelegate>()
        {
            // attack ended
            (enemy) => { return this.GetRange() < Vector2.Distance(PlayerManager.Instance.player.transform.position, this.transform.position); }
        };

        list2 = new List<Transition.MyDelegate>()
        {
            // ?
        };

        list3 = new List<Transition.MyDelegate>()
        {
            (enemy) => { return this.GetRange() >= Vector2.Distance(PlayerManager.Instance.player.transform.position, this.transform.position); }
            //(enemy) => { return enemy.GetRange() >= Vector2.Distance(new Vector2(1,1), new Vector2(9,9)); }
        };

        list4 = new List<Transition.MyDelegate>()
        {
            // Player Uses Bow / raycast it enemy, 50% chance, dodge isnt on cooldown
        };

        transList1 = new List<Transition>()
        {
            new Transition(eUnitState.MOVE, list1, this),

        };

        transList2 = new List<Transition>()
        {
            new Transition(eUnitState.MOVE, list2, this),

        };

        transList3 = new List<Transition>()
        {
            new Transition(eUnitState.ATTACK, list3, this),
            new Transition(eUnitState.DODGE, list4, this),

        };

        stateDict = new Dictionary<eUnitState, BaseState> {
            { eUnitState.ATTACK, new AttackState(this, transList1) },
            { eUnitState.DODGE, new DodgeState(this, transList2) },
            { eUnitState.MOVE, new MoveState(this,transList3) }
        };

        grid = new Grid();

        stateM = new StateMachine(eUnitState.MOVE, stateDict);

    }

    private void OnCollisionEnter(Collision collision)
    {

        //inAir = false;

    }

    void LaunchSlime()
    {
        YeetSlime yS = GameObject.Instantiate(Resources.Load<YeetSlime>(PrefabsDir.slimeDir)).GetComponent<YeetSlime>();
        yS.gameObject.GetComponent<Rigidbody2D>().AddForce((transform.position + new Vector3(transform.position.x,transform.position.y-1,0).normalized));
            
    }

}
