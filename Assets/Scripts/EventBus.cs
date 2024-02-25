using System;
using UnityEngine.UI;

public static class EventBus 
{
    //skills
    public static Action<float> OnCastStarted;
    public static Action<float> OnDelayStarted;
    
    //heroes
    public static Action<float, Hero> OnTakeDamage;
    public static Action OnPlayerDied;
    public static Action OnEnemyDied;

    public static void StartCasting(float castTime) => 
        OnCastStarted?.Invoke(castTime);

    public static void DelayStart(float delayTime) =>
        OnDelayStarted?.Invoke(delayTime);

    public static void TakeDamage(float damage, Hero hero) => 
        OnTakeDamage?.Invoke(damage, hero);

    public static void PlayerDie() => 
        OnPlayerDied?.Invoke();

    public static void EnemyDie() => 
        OnEnemyDied?.Invoke();
}
