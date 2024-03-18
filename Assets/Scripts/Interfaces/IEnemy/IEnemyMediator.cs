using UnityEngine;

namespace Assets.Scripts.Interfaces.IEnemy
{
    public interface IEnemyMediator
    {
        public void SetTarget(Transform player);

        public void LifeZero();

        public void DoMove();

        public void DoBooster(Transform collisionPosition);

        public void GetTarget();

        public void DoTarget(Vector3 target);
    }
}