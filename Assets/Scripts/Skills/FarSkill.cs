using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class FireSkill : ISkillDamage
{
    public AttackObjectsFactory AttackObjectsFactory { get; set; }
    public float CastTime { get; set; }
    public float Delay { get; set; }
    public bool isDelayed { get; set; }

    private AttackObjectsFactory factory;
    private Transform _aim;

    private float _flyObjectTime;


    public FireSkill(float delay, float cast, float flyObjectTime, string objectPath, Transform spawnPos, Transform aim)
    {
        _flyObjectTime = flyObjectTime;
        _aim = aim;
        Delay = delay;
        CastTime = cast;
        isDelayed = false;

        factory = new AttackObjectsFactory(objectPath, spawnPos);
    }


    public void Attack(Heroes aim)
    {
        if (isDelayed == false)
        {
            CoroutineHandler.Instance.StartRoutine(StartCastRoutine());
        }
    }

    public event Action<float> OnStartedCast;


    private IEnumerator DelayBetweenAttackRoutine()
    {
        yield return new WaitForSeconds(this.Delay);
        isDelayed = false;
    }

    private IEnumerator StartCastRoutine()
    {
        
        OnStartedCast?.Invoke(_flyObjectTime);
        yield return new WaitForSeconds(_flyObjectTime);
        
        var attackObj = factory.GetObject();
        attackObj.gameObject.transform.DOMove(new Vector3(_aim.transform.position.x, _aim.transform.position.y, _aim.transform.position.z), _flyObjectTime);
        
        isDelayed = true;
        
        CoroutineHandler.Instance.StartRoutine(DelayBetweenAttackRoutine());
    }

    private void StopCastRoutine()
    {
        CoroutineHandler.Instance.StopCoroutine(StartCastRoutine());
    }
}
