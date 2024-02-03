using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GameObject _enemy;
 

    private void Start()
    {
        
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var movement = new Vector3(horizontal, 0, vertical);
        movement = transform.TransformDirection(movement);
        
        _rigidbody.velocity = movement * _speed;
        
        transform.LookAt(_enemy.transform.position);
        

    }

}