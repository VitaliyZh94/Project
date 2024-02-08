using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseHeroState : IState
{
    public void Enter()
    {
        Debug.Log("Enter ChooseHeroState");
        SceneManager.LoadScene(Constants.ChooseHero);
    }

    public void Exit()
    {
        Debug.Log("Exit ChooseHeroState");
    }
}