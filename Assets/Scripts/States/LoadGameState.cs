using System.Collections;
using UnityEngine;

public class LoadGameState : IState
{
    private FakeLoading _fakeLoading;
    private GameStateMachine _gameStateMachine;

    public LoadGameState(GameStateMachine gameStateMachine, FakeLoading fakeLoading)
    {
        _fakeLoading = fakeLoading;
        _gameStateMachine = gameStateMachine;
    }
    
    public void Enter()
    {
        _fakeLoading.ShowCurtain();
        CoroutineHandler.Instance.StartRoutine(ChangeStateAfterFakeTimeRoutine());
    }

    public void Exit() => 
        Debug.Log("Exit LoadGameState");

    private IEnumerator ChangeStateAfterFakeTimeRoutine()
    {
        yield return new WaitForSeconds(3f);
        
        _gameStateMachine.ChangeState(new MainMenuState());
    }
}