using System;
using UnityEngine;

public class Warrior : Heroes
{
    private Transform _position;
    public override float SimpleDamageDelay { get; set; }
    public override float SkillDamageDelay { get; set; }
    public override float ManaRecoverySpeed { get; set; }

    public Warrior(float hp, float mana, float simpleDamageDelay, float skillDamageDelay, float manaRecoverySpeed)
    {
        base.health = hp;
        base.mana = mana;
        SimpleDamageDelay = simpleDamageDelay;
        SkillDamageDelay = skillDamageDelay;
        ManaRecoverySpeed = manaRecoverySpeed;
    }
    
    public override Transform Position
    {
        get => _position;
        set => _position = this.transform;
    }

    public override float SkillDamage(float damage)
    {
        return damage;
    }

    public override float SimpleDamage(float damage)
    {
        throw new System.NotImplementedException();
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