using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SkillController : MonoBehaviour
{
    [SerializeField] private float _castTimeHardFarSkill;
    [SerializeField] private float _manaCostHardFarSkill;


    private HardFarSkill _hardFarSkill;
    private SimpleFarSkill _simpleFarSkill;
    private Player _player;
    private Transform _spawnPos;

    [Inject]
    private void Constr(Player player) => 
        _player = player;

    private void Start()
    {
        var spawnPos = _player.GetComponent<SpawnPos>();
        _spawnPos = spawnPos.GetSpawnPos();
        var anim = _player.GetComponent<PlayerAnim>();

        _simpleFarSkill = new SimpleFarSkill(1, Constants.SimpleBall, _spawnPos);
        _hardFarSkill = new HardFarSkill(3, _castTimeHardFarSkill, Constants.IceBallPrefabPath, _spawnPos, _player, _manaCostHardFarSkill, anim);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
            _hardFarSkill.Attack();
        
        if (Input.GetKeyDown(KeyCode.O)) 
            _simpleFarSkill.Attack();
    }
}