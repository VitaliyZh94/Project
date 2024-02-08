using System;
using UnityEngine;

public class Warrior : Heroes
{
    private Transform _position;

    public override float ManaRecoverySpeed { get; set; }

    public Warrior(float hp, float mana, float manaRecoverySpeed)
    {
        base.health = hp;
        base.mana = mana;

        ManaRecoverySpeed = manaRecoverySpeed;
    }
    
    public override Transform Position
    {
        get => _position;
        set => _position = this.transform;
    }
    

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    public override void StopAttack()
    {
        throw new System.NotImplementedException();
    }

    public override float TakeDamage(float damage)
    {
        throw new System.NotImplementedException();
    }
}