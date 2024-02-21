using UnityEngine;

public abstract class AttackObject : MonoBehaviour
{
    [SerializeField] protected float Damage;
    
    protected IDamageable Damageable;
    public abstract void Attack();
}