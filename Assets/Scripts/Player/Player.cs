using System;
using UnityEngine;

public class Player : Heroes
{
    [SerializeField] private float _manaRecoverySpeed;
    [SerializeField] private float _mana;
    [SerializeField] private float _hp;
    
    public static Action OnPlayerDied;

    private void Awake()
    {
        ManaRecoverySpeed = _manaRecoverySpeed;
        MaxMana = _mana;
        HP = _hp;
        Mana = _mana;
    }
    
    protected override void Die()
    {
        Debug.Log("DIE");
        OnPlayerDied?.Invoke();
    }
}
