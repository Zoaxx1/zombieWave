﻿using Assets.Scripts.Enemies.Attack;
using Assets.Scripts.Enemies.Life;
using Assets.Scripts.Enemies.Movement;
using Assets.Scripts.Interfaces.IEnemy;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class EnemyMediator : MonoBehaviour, IEnemyMediator
    {
        [SerializeField] EnemyController enemy;
        [SerializeField] EnemyLife enemyLife;
        [SerializeField] EnemyMover enemyMover;
        [SerializeField] EnemyBooster enemyBooster;
        [SerializeField] EnemyObjectiveMarker enemyObjectiveMarker;

        private void Awake()
        {
            enemy.Configure(this);
            enemyLife.Configure(this);
        }

        public void SetTarget(Transform player)
        {
            enemyObjectiveMarker.Configure(this, player);
        }

        public void LifeZero() =>
            enemy.DoRecycle();

        public void DoMove() =>
            enemyMover.Move();

        public void DoBooster(Transform collisionPosition) =>
            enemyBooster.Impulse(collisionPosition);

        public void GetTarget() =>
            enemyObjectiveMarker.TargetPlayer();

        public void DoTarget(Vector3 target) =>
            enemyMover.SetDirection(target);
    }
}