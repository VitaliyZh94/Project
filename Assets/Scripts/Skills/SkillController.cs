using System;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    [SerializeField] private Transform _spawnPos;
    [SerializeField] private Heroes _player;
    
    [SerializeField] private float _castTimeHardFarSkill;
    [SerializeField] private float _manaCostHardFarSkill;
    
    private HardFarSkill _hardFarSkill;
    private SimpleFarSkill _simpleFarSkill;
    private void Start()
    {
        _simpleFarSkill = new SimpleFarSkill(1, Constants.SimpleBall, _spawnPos);
        _hardFarSkill = new HardFarSkill(3, _castTimeHardFarSkill, Constants.IceBallPrefabPath, _spawnPos, _player, _manaCostHardFarSkill);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
            _hardFarSkill.Attack();
        
        if (Input.GetKeyDown(KeyCode.O)) 
            _simpleFarSkill.Attack();
    }
}