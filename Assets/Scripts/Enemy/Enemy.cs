using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Zenject;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : Hero, IMoveble
{
    
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private NavMeshAgent agent;
    
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _hp = 100f;
    [SerializeField] private float _mana = 100f;
    
    private Player _player;

    [Inject]
    private void Constr(Player player) => 
        _player = player;

    public float Speed { get; set; }
    
    private float _startSpeed;
    
    private void Awake()
    {
        _startSpeed = _speed;
        Speed = _speed;
        agent.speed = Speed;
        HP = _hp;
        Mana = _mana;
    }
    
    private void Update()
    {
        var distToPlayer = (_player.transform.position - transform.position).magnitude;
        
        if (distToPlayer < 5f)
        {
            Attack();
            agent.SetDestination(gameObject.transform.position);
            _rb.isKinematic = true;
        }
        else
        {
            _rb.isKinematic = false;
            Move();
        }
    }
    public void Move() => 
        agent.SetDestination(_player.transform.position);
    
    public void StopMoving() => 
        StartCoroutine(StopMovingRoutine());

    private IEnumerator StopMovingRoutine()
    {
        agent.speed = 0;
        yield return new WaitForSeconds(3);
        agent.speed = _startSpeed;
    }
    
    protected override void Die()
    {
        agent.SetDestination(transform.position);
        _rb.isKinematic = true;
        EventBus.EnemyDie();
    }
    
    private void Attack() => 
        _player.GetComponent<Player>().TakeDamage(_damage);
}
