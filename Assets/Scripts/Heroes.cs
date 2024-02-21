using System;
using UnityEngine;


public abstract class Heroes : MonoBehaviour, IDamageable
{
    protected float ManaRecoverySpeed;
    protected float MaxMana;
    
    private float _health;
    private float _curMana;
    private bool _startDie = true;


    private void Update()
    {
        Mana += ManaRecoverySpeed * Time.deltaTime;
        
    }

    public void TakeDamage(float damage)
    {
        HP -= damage; 
        EventBus.TakeDamage(damage);
    }

    public void ChangeMana(float mana)
    {
        _curMana -= mana;
    }

    public float HP
    {
        get => _health;
        
        set
        {
            if (value <= 0 )
            {
                _health = 0;
                
                if (_startDie)
                {
                    Die();
                    _startDie = false;
                }
            }
            
            else
                _health = value;
        }
    }

    public float Mana
    {
        get => _curMana;
        
        set
        {
            if (value <= 0)
                _curMana = 0;
            
            else if (value >= MaxMana)
                  _curMana = MaxMana;
            
            else
                _curMana = value;
        }
    }
    protected abstract void Die();

}