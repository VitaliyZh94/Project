using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine
{
    public IState CurrentState {get; private set; }

    public void Initialize(IState startState)
    {
        CurrentState = startState;
        CurrentState.Enter();
    }

    public void ChangeState(IState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}