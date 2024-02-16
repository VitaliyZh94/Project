using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : IState
{
    public void Enter() => 
        SceneManager.LoadScene(Constants.MenuScene);

    public void Exit() => 
        Debug.Log("Exit MenuState");
}