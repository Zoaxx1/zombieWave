using Assets.Scripts.Enemies;
using Assets.Scripts.ObjectPools;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    public class EnemyFactoryService
    {
        EnemyController _enemy;

        Transform _playerTarget;

        ObjectPool _objectPool;

        public void Configure(
            EnemyController enemy,
            Transform playerTarget
            )
        {
            _enemy = enemy;
            _playerTarget = playerTarget;

            _objectPool = new ObjectPool(enemy);
        }

        public void Create(Vector3 position)
        {
            var enemyInstantiate = _objectPool.Instantiate(position, _enemy.transform.rotation);

            enemyInstantiate.GetComponent<EnemyController>().SetTarget(_playerTarget);
        }
    }
}
