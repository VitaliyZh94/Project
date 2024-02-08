using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WarriorSettings", menuName = "ScriptableObjects/WarriorSettings")]
public class WarriorSettings : ScriptableObject
{
    public float HP;
    public float Mana;
    public float SkillDamage;
    public float SimpleDamage;
    public float ManaRecoverySpeed;
    public float SimpleDamageDelay;
    public float SkillDamageDelay;
    
}
