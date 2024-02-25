using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HardFarSkill : Skills
{
    private Hero _player;
    private Image _skillImage;
    private PlayerAnim _playerAnim;
    
    private float _manaCost;

    public HardFarSkill(float delay, float castTime, string objectPath, Transform spawnPos, Hero player, float manaCost, PlayerAnim playerAnim)
    {
        _manaCost = manaCost;
        CastTime = castTime;
        _delay = delay;
        _isDelayed = false;
        _player = player;
        _playerAnim = playerAnim;

        _factory = new AttackObjectsFactory(objectPath, spawnPos);
    }


    public override void Attack()
    {
        if (_isDelayed == false && IsEnoughtManaToAttack())
        {
            CoroutineHandler.Instance.StartRoutine(ShotRoutine());
            
            _player.GetComponent<PlayerMove>().StopMoving();
            _player.ChangeMana(_manaCost);
        }
    }

    private IEnumerator ShotRoutine()
    {
        _isDelayed = true;
        EventBus.StartCasting(CastTime);
        _playerAnim.Cast();
        
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