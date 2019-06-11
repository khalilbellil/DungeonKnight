using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition
{
    public delegate bool MyDelegate(Enemy enemy);

    bool evaluate;
    public StateMachine.eUnitState toState;
    List<MyDelegate> list;
    Enemy enemy;

   public Transition(StateMachine.eUnitState toState, List<MyDelegate> list, Enemy enemy )
   {
        this.toState = toState;
        this.list = list;
        this.enemy = enemy;
   }

    public bool Evluate()
    {
        foreach(MyDelegate d in list)
        {
            if (!d.Invoke(enemy))
                return false;
        }
        return true;
    }

}
