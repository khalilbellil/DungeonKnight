using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    eUnitState currentState;

    Dictionary<eUnitState, BaseState> stateDict;

    public StateMachine(eUnitState currentState, Dictionary<eUnitState, BaseState> stateDict)
    {
        this.currentState = currentState;
        this.stateDict = stateDict;
    }

    public void Update()
    {
        stateDict[currentState].Update();
        eUnitState newState = stateDict[currentState].Evaluate();
        if (newState != currentState)
        {
            stateDict[currentState].Exit();
            currentState = newState;
            stateDict[currentState].Enter();
        }
    }

    public void FixedUpdate()
    {
        stateDict[currentState].FixedUpdate();
    }

}
