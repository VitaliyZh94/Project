using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class FireBall : AttackObject
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _speedReduction;

    private IMoveble moveble;
    private Vector3 aimPos;
    private Enemy _aim;
    private Rigidbody _rb;

    private void Start()
    {
        //_rb = GetComponent<Rigidbody>(); ???
    }
    

    public override float Damage
    {
        get => _damage;
        set => Damage = _damage;
    }

    public override void Debuff()
    {
        //StartCoroutine(SlowDown());
    }

    public override void Attack()
    {
        var vector = gameObject.transform.forward;
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(vector * _speed, ForceMode.VelocityChange);
        _rb.useGravity = false;
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out moveble))
        {
            Debug.Log("FREEZ");
            gameObject.SetActive(false);
            moveble.StopMoving();
            
            //Debuff();
        }
    }


    // private IEnumerator SlowDown()

    // {

    //     var curSpeed = _aim.MoveSpeed;

    //     

    //     if (curSpeed >= _speedReduction)

    //     {

    //         var newSpeed = curSpeed - _speedReduction;

    //         _aim.MoveSpeed = newSpeed;

    //         yield return new WaitForSeconds(_speedReduction);

    //         _aim.MoveSpeed = curSpeed;

    //     }

    // }
}