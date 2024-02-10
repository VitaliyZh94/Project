using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private Heroes _enemy;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] public float _cast;
    [SerializeField] private Transform _spawnPos;
   
    [SerializeField] private float _speed;

    [SerializeField] private float _rotateSpeed;

    private ISkillDamage skill;
    
    public bool IsCanMove = true;

    private void OnEnable()
    {
        skill = new FarSkill(3, _cast, 1, "FireBall", _spawnPos, _enemy.transform);
        skill.OnStartedCast += StopMoving;
    }

    private void OnDisable()
    {
        skill.OnStartedCast -= StopMoving;
    }

    private void Update()
    {
        if (IsCanMove == true)
        {
            Move();
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            skill.Attack(_enemy);
        }
    }

    public void StopMoving(float castTime) => 
        StartCoroutine(StopMoveRoutine(castTime));

    private void Move()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var verticalMove = new Vector3(0,0,vertical) * _speed * Time.deltaTime;
        var horizontalRotate = new Vector3(0,horizontal,0) * _rotateSpeed * Time.deltaTime;

        transform.Translate(new Vector3(horizontal, 0, vertical) * _speed * Time.deltaTime);
        transform.forward = (_enemy.transform.position - transform.position).normalized;
    }


    private IEnumerator StopMoveRoutine(float castTime)
    {
        IsCanMove = false;
        _rigidbody.isKinematic = true;
        yield return new WaitForSeconds(castTime);
        _rigidbody.isKinematic = false;
        IsCanMove = true;
    }
}

