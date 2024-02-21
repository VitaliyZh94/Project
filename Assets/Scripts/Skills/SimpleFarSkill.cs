using System.Collections;
using UnityEngine;

public class SimpleFarSkill : Skills
{
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

        yield return new WaitForSeconds(_delay);
        
        _isDelayed = false;
    }
}