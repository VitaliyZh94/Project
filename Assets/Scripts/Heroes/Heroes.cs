using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Heroes : MonoBehaviour, IDamagetable
{
    public Action OnTakeDamaged;
    public Action OnEnemyDied;
    public Action OnPlayerDied;
    
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

    public abstract float ManaRecoverySpeed { get; set; }

    public abstract void Move();
    public abstract void StopAttack();


    public virtual float TakeDamage(float damage)
    {
        OnTakeDamaged?.Invoke();
        return damage;
    }
}