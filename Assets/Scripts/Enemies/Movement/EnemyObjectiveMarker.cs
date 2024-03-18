using Assets.Scripts.Interfaces.IEnemy;
using UnityEngine;

namespace Assets.Scripts.Enemies.Movement
{
    public class EnemyObjectiveMarker : MonoBehaviour
    {
        [SerializeField] Rigidbody rb;
        [SerializeField] float speed;
        [SerializeField] float speedRotation;

        IEnemyMediator _mediator;
        Transform _player;

        public void Configure(IEnemyMediator mediator, Transform player)
        {
            _mediator = mediator;
            _player = player;
        }

        public void TargetPlayer()
        {
            Quaternion lookPlayer = Quaternion.LookRotation(_player.position - transform.position);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookPlayer, speedRotation * Time.deltaTime);

            Vector3 targetPlayer = ((_player.position - transform.position).normalized);

            _mediator.DoTarget(targetPlayer);
        }
    }
}