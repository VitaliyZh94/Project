using System;
using System.Collections;
using UnityEngine;

public class HardFarSkill : Skills
{
    private Heroes _player;
    private float _manaCost;
    
    public HardFarSkill(float delay, float castTime, string objectPath, Transform spawnPos, Heroes player, float manaCost)
    {
        _manaCost = manaCost;
        CastTime = castTime;
        _delay = delay;
        _isDelayed = false;
        _player = player;

        _factory = new AttackObjectsFactory(objectPath, spawnPos);
    }


    public override void Attack()
    {
        if (_isDelayed == false && IsEnoughtManaToAttack())
        {
            _player.GetComponent<PlayerMove>().StopMoving();
            _player.ChangeMana(_manaCost);
            
            CoroutineHandler.Instance.StartRoutine(ShotRoutine());
        }
    }

    private IEnumerator ShotRoutine()
    {
        _isDelayed = true;
        EventBus.StartCasting(CastTime);
        
        yield return new WaitForSeconds(CastTime);
        
        var attackObj = _factory.GetObject();
        attackObj.Attack();
        
        EventBus.DelayStart(_delay);
        
        CoroutineHandler.Instance.StartRoutine(DelayBetweenAttackRoutine());
    }

    private IEnumerator DelayBetweenAttackRoutine()
    {
        yield return new WaitForSeconds(_delay);
        _isDelayed = false;
    }

    private bool IsEnoughtManaToAttack()
    {
        var curMana = _player.Mana;

        if (curMana >= _manaCost)
            return true;
        else
            return false;
    }
}