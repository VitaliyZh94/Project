using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkillDamage : ISkill
{
    public AttackObjectsFactory AttackObjectsFactory { get; set; }
    public void Attack(Heroes aim);
    public static Action<float> OnStartedCast;  //use this in realized classes

}