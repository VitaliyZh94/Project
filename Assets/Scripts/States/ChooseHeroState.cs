using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseHeroState : IState
{
    public void Enter() => 
        SceneManager.LoadScene(Constants.ChooseHeroScene);

    public void Exit() => 
        Debug.Log("Exit ChooseHeroState");
}