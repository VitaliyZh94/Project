using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : Heroes, IMoveble
{
    
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform _heroe;
    
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    public float Speed { get; set; }
    
    private float _startSpeed;
    
    private void Awake()
    {
        _startSpeed = _speed;
        Speed = _speed;
        agent.speed = Speed;
        HP = 100f;
        Mana = 100f;
    }
    
    private void Update()
    {
        var distToPlayer = (_heroe.position - transform.position).magnitude;
        
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
        agent.SetDestination(_heroe.position);
    
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
        _heroe.GetComponent<Player>().TakeDamage(_damage);
}
