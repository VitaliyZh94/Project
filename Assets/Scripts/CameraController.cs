using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Zenject;

public class CameraController : MonoBehaviour
{
   [SerializeField] private CinemachineVirtualCamera _cinemachineVirtual;
   [SerializeField] private Enemy _enemy;
   
   private Player _player;

   [Inject]
   private void Const(Player player)
   {
      _player = player;
   }

   private void Start()
   {
      if(!_player) return;
      _cinemachineVirtual.enabled = true;
      _cinemachineVirtual.Follow = _player.transform;
      _cinemachineVirtual.m_Lens.FieldOfView = 60f;
   }
}
