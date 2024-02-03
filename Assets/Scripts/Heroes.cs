using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Heroes : MonoBehaviour, IDamagetable
{
    protected float health;
    protected float mana;
    
    public abstract Transform Position { get; set; }
    public float HP
    {
        get => health;
        set
        {
            if (value < 0)
                health = 0;
            else
                health = value;
        }
    }
    public float Mana
    {
        get => mana;
        set
        {
            if (value < 0)
                mana = 0;
            else
                mana = value;
        }
    }
    public abstract float SimpleDamageDelay { get; set; }
    public abstract float SkillDamageDelay { get; set; }
    public abstract float ManaRecoverySpeed { get; set; }
    
    public abstract float SkillDamage(float damage);
    
    public abstract float SimpleDamage(float damage);

    public abstract void Move();
    public abstract void StopAttack();

    public virtual float TakeDamage(float damage)
    {
        OnTakeDamaged?.Invoke();
        return damage;
    }

    public Action OnTakeDamaged;

}