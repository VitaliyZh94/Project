using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : Heroes
{
    public override Transform Position { get; set; }
    public override float ManaRecoverySpeed { get; set; }

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform _heroe;

    private void Update()
    {
        Move();
    }

    public override void Move()
    {
        agent.SetDestination(_heroe.position);
    }

    public override void StopAttack()
    {
        
    }
}
