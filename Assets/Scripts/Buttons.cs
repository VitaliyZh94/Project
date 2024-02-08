using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    private GameStateMachine _gameStateMachine;
    void Start()
    {
        _gameStateMachine = EntryPoint.Instance.GameStateMachine; 
    }

    public void EnterChooseHeroState() =>
        _gameStateMachine.ChangeState(new ChooseHeroState());

    public void EnterCoreState() => 
        _gameStateMachine.ChangeState(new CoreState());

    public void EnterMenuState() => 
        _gameStateMachine.ChangeState(new MainMenuState());
}
