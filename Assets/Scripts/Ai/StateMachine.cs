using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum eUnitState { ATTACK, MOVE, DODGE }

    eUnitState currentState = eUnitState.MOVE;

    /*Dictionary<eUnitState, BaseState> stateDict = new Dictionary<eUnitState, BaseState> {
        { eUnitState.ATTACK, new AttackState() },
        { eUnitState.MOVE, new MoveState() },
        { eUnitState.DODGE, new DodgeState() }
    };*/

    public void Update()
    {
        //updateSenses();

        /*stateDict[currentState].Update();
        eUnitState newState = stateDict[currentState].Evaluate();
        if (newState != currentState)
        {
            stateDict[currentState].Exit();
            currentState = newState;
            stateDict[currentState].Enter();
        }*/
    }

}
