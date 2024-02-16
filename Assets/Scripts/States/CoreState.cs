using UnityEngine;
using UnityEngine.SceneManagement;

public class CoreState : IState
{
    public void Enter() => 
        SceneManager.LoadScene(Constants.CoreScene);

    public void Exit() => 
        Debug.Log("Exit CoreState");
}