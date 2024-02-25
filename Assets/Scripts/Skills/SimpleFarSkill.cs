using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SimpleFarSkill : Skills
{
    private Image _skillImage;
    public SimpleFarSkill(float delay, string objectPath, Transform spawnPos)
    {
        _delay = delay;
        _isDelayed = false;

        _factory = new AttackObjectsFactory(objectPath, spawnPos);
    }
    
    public override void Attack()
    {
        if (_isDelayed == false)
        {
            CoroutineHandler.Instance.StartRoutine(ShotRoutine());
        }
    }

    private IEnumerator ShotRoutine()
    {
        _isDelayed = true;
        
        var attacjObj = _factory.GetObject();
        attacjObj.Attack();
        
        EventBus.DelayStart(_delay);

        yield return new WaitForSeconds(_delay);
        
        _isDelayed = false;
    }
}