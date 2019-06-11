using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum eUnitState { ATTACK, MOVE, DODGE }

    //Dictionary<eUnitState, BaseState> stateDict = new Dictionary<eUnitState, BaseState> { { eUnitState.ATTACK, new AttackState() }, { eUnitState.MOVE, new MoveState() }, { eUnitState.DODGE, new DodgeState() } };

    public void Update()
    {
        //updateSenses();

        //stateDict[CurrentState].update();
        //eUnitState newState = stateDict[CurrentState].Evaluate();
        /*if (newState != CurrentState)
        {
            stateDict[CurrentState].Exit();
            CurrentState = newState;
            stateDict[CurrentState].Enter();
        }*/
    }

}
