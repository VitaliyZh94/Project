using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Heroes
{


    public override Transform Position { get; set; }
    public override float SimpleDamageDelay { get; set; }
    public override float SkillDamageDelay { get; set; }
    public override float ManaRecoverySpeed { get; set; }
    public override float SkillDamage(float damage)
    {
        return 3f;
    }

    public override float SimpleDamage(float damage)
    {
        return 3f;
    }

    public override void Move()
    {
        
    }

    public override void StopAttack()
    {
        
    }
}
