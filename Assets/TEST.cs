using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    [SerializeField] private Transform _spawnPos;
    [SerializeField] private Heroes _enemy;
    [SerializeField] public float _cast = 1;

    private ISkillDamage a;

    void Start()
    {
        a = new FireSkill(3, _cast, 1, "FireBall", _spawnPos, _enemy.transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            a.Attack(_enemy);
        }
    }
}
