using DG.Tweening;
using UnityEngine;

public class FireBall : AttackObject
{
    [SerializeField] private float _damage;

    protected override float damage
    {
        get => damage;
        set => damage = _damage;
    }
}