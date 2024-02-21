using System;

public static class EventBus 
{
    //
    // private static EventBus _instance;
    // public static EventBus Instance
    // {
    //     get
    //     {
    //         if (_instance == null)
    //             _instance = new EventBus();
    //
    //         return _instance;
    //     }
    // }
    //
    // public void Init()
    // {
    //     _instance = new EventBus();
    // }
    
    //skills
    public static Action<float> OnCastStarted;
    public static Action<float> OnDelayStarted;
    
    //heroes
    public static Action<float> OnTakeDamage;
    public static Action OnPlayerDied;
    public static Action OnEnemyDied;

    public static void StartCasting(float castTime) => 
        OnCastStarted?.Invoke(castTime);

    public static void DelayStart(float delayTime) => 
        OnDelayStarted?.Invoke(delayTime);

    public static void TakeDamage(float damage) => 
        OnTakeDamage?.Invoke(damage);

    public static void PlayerDie() => 
        OnPlayerDied?.Invoke();

    public static void EnemyDie() => 
        OnEnemyDied?.Invoke();
}
