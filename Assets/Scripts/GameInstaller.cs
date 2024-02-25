using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class GameInstaller : MonoInstaller
{
   [SerializeField] private Player _playerPrefab;
   [SerializeField] private Enemy _enemyPrefab;
   [SerializeField] private Transform _playerSpawnPoint;
   [SerializeField] private Transform _enemySpawnPoint;
   public override void InstallBindings()
   {
      BindPlayer();
      BindEnemy();
   }


   private void BindPlayer()
   {
      var player =
         Container.InstantiatePrefabForComponent<Player>(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity,_playerSpawnPoint);

      Container.Bind<Player>().FromInstance(player).AsSingle();
   }

   private void BindEnemy()
   {
      var enemy = Container.InstantiatePrefabForComponent<Enemy>(_enemyPrefab, _enemySpawnPoint.position, Quaternion.identity, _enemySpawnPoint);
      Container.Bind<Enemy>().FromInstance(enemy).AsSingle();
   }
}
