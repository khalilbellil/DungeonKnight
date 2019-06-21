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
        Debug.Log(currentState);
        eUnitState newState = stateDict[currentState].Evaluate();
        if (newState != currentState)
        {
            stateDict[currentState].Exit();
            currentState = newState;
            try
            {
                stateDict[currentState].Enter();

            }
            catch
            {
                Debug.Log("");
            }
        }
    }

    public void FixedUpdate()
    {
        stateDict[currentState].FixedUpdate();
    }

}
