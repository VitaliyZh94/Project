using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuState : IState
{

    public void Enter() => 
        SceneManager.LoadScene(Constants.Menu);

    public void Exit()
    {
        Debug.Log("Exit MenuState");
    }
}