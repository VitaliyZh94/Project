using UnityEngine;

public class HeroesUI : MonoBehaviour
{
    private void OnEnable()
    {
        EventBus.OnEnemyDied += Hide;
        EventBus.OnPlayerDied += Hide;
    }

    private void OnDisable()
    {
        EventBus.OnEnemyDied -= Hide;
        EventBus.OnPlayerDied -= Hide;
    }
    
    private void Hide() => 
        gameObject.SetActive(false);
}