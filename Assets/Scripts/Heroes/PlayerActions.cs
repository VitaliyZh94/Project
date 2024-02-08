using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Rigidbody _rigidbody;
   
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    

    public bool IsCanMove = true;

    private void OnEnable()
    {
        ISkillDamage.OnStartedCast += StopCasting;
    }

    private void OnDisable()
    {
        ISkillDamage.OnStartedCast -= StopCasting;
    }

    private void Update()
    {
        if (IsCanMove == true)
        {
            Move();
        }
    }

    private void Move()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var verticalMove = new Vector3(0,0,vertical) * _speed * Time.deltaTime;
        var horizontalRotate = new Vector3(0,horizontal,0) * _rotateSpeed * Time.deltaTime;

        transform.Translate(new Vector3(horizontal, 0, vertical) * _speed * Time.deltaTime);
        transform.forward = (_enemy.transform.position - transform.position).normalized;
    }


    private void StopCasting(float castTime) => 
        StartCoroutine(StopMoveRoutine(castTime));

    private IEnumerator StopMoveRoutine(float castTime)
    {
        IsCanMove = false;
        _rigidbody.isKinematic = true;
        yield return new WaitForSeconds(castTime);
        _rigidbody.isKinematic = false;
        IsCanMove = true;
    }
}

