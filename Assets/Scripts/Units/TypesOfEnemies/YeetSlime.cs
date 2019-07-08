using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YeetSlime : Enemy
{
    bool inAir;
    public int yeetForce;
    float timealive;


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

        timealive = Time.time;

        target = EnemyManager.Instance.enemiesAlive[0].transform;

        list1 = new List<Transition.MyDelegate>()
        {
            (enemy) => { return !this.inAir; }
        };

        list2 = new List<Transition.MyDelegate>()
        {
            (enemy) => { return false; }
        };

        transList1 = new List<Transition>()
        {
            new Transition(eUnitState.MOVE, list1, this),

        };

        transList2 = new List<Transition>()
        {
            new Transition(eUnitState.IDLE, list2, this)
        };

        stateDict = new Dictionary<eUnitState, BaseState> {
            { eUnitState.IDLE, new IdleState(this, transList1) },
            { eUnitState.MOVE, new MoveState(this,transList2) }
        };

        grid = new Grid();

        stateM = new StateMachine(eUnitState.IDLE, stateDict);

    }

    public void Launched(Vector2 dir)
    {
        rb.AddForce(dir.normalized * yeetForce,ForceMode2D.Impulse);
        inAir = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerManager.Instance.player.TakeDamage(5);
        }

        if ((Time.time - timealive > 4))
        {
            inAir = false;
            if (collision.transform.CompareTag("Boss"))
            {
                EnemyManager.Instance.enemiesAlive.Remove(this);
                GameObject.Destroy(this.gameObject);
                Debug.Log("Consumed");
            }
        }

    }

    public bool getInAir()
    {
        return inAir;
    }
}
