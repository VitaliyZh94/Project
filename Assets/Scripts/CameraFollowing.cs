using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void LateUpdate() => 
        transform.LookAt(_player.forward);
}
