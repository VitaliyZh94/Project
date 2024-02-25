using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Freeze(bool isFreeze) => 
        _animator.SetBool(Constants.FreezeAnim, isFreeze);

    public void Attack(bool isAttack) => 
        _animator.SetBool(Constants.AttackAnim, isAttack);
}