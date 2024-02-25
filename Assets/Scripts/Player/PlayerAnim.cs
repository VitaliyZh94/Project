using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Run(float speed) => 
        _animator.SetFloat(Constants.RunAnim, speed);

    public void Cast() => 
        _animator.SetTrigger(Constants.CastAnim);
}