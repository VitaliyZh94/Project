using UnityEngine;
using UnityEngine.SceneManagement;

public class CoreState : IState
{
    public void Enter()
    {
        Debug.Log("Enter CoreState");
        SceneManager.LoadScene(Constants.Core);
    }

    public void Exit()
    {
        Debug.Log("Exit CoreState");
    }
}