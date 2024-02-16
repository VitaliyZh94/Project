using System.Collections;
using UnityEngine;

public class FarSkill : Skills
{
    private AttackObjectsFactory _factory;
    private Heroes _aim;
    private Heroes _player;
    
    private float _castTime;
    private float _delay;
    private float _manaCost;
    private bool _isDelayed;
    
    
    public FarSkill(float delay, float castTime, string objectPath, Transform spawnPos, Heroes player, float manaCost)
    {
        _manaCost = manaCost;
        _castTime = castTime;
        _delay = delay;
        _isDelayed = false;
        _player = player;

        _factory = new AttackObjectsFactory(objectPath, spawnPos);
    }


    public void Attack(Heroes aim)
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
        OnCastStarted?.Invoke(_castTime);
        
        yield return new WaitForSeconds(_castTime);
        
        var attackObj = _factory.GetObject();
        attackObj.Attack();
        
        OnDelayStarted?.Invoke(_delay);
        
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