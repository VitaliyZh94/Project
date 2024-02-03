using System;
using System.Collections;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FireSkill : ISkillDamage
{
    
    public AttackObjectsFactory AttackObjectsFactory { get; set; }
    public float delay { get; set; }
    public bool isDelayed { get; set; }
    
    private AttackObjectsFactory factory;
    private Transform _aim;
    
    private float _flyTime;
    private float _castTime;

    public FireSkill(float delay, float cast, float flyTime, string objectPath, Transform spawnPos, Transform aim)
    {
        _flyTime = flyTime;
        _aim = aim;
        this.delay = delay;
        _castTime = cast;
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


    private IEnumerator DelayBetweenAttackRoutine()
    {
        yield return new WaitForSeconds(this.delay);
        isDelayed = false;
    }

    private IEnumerator StartCastRoutine()
    {
        
        ISkillDamage.OnStartedCast?.Invoke(_castTime);
        yield return new WaitForSeconds(_castTime);
        
        var attackObj = factory.GetObject();
        attackObj.gameObject.transform.DOMove(new Vector3(_aim.transform.position.x, _aim.transform.position.y, _aim.transform.position.z), _flyTime);
        
        isDelayed = true;
        
        CoroutineHandler.Instance.StartRoutine(DelayBetweenAttackRoutine());
    }

    private void StopCastRoutine()
    {
        CoroutineHandler.Instance.StopCoroutine(StartCastRoutine());
    }
}