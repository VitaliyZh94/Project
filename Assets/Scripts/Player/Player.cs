using System;
using UnityEngine;

public class Player : Hero
{
    [SerializeField] private float _manaRecoverySpeed;
    [SerializeField] private float _mana;
    [SerializeField] private float _hp;

    private void Awake()
    {
        ManaRecoverySpeed = _manaRecoverySpeed;
        MaxMana = _mana;
        HP = _hp;
        Mana = _mana;
    }

    protected override void Die()
    {
        EventBus.PlayerDie();
    }
}
