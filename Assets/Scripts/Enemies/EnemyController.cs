using Assets.Scripts.Interfaces.IEnemy;
using Assets.Scripts.ObjectPools;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class EnemyController : RecyclableObject
    {
#if UNITY_EDITOR
        [SerializeField] bool isEnemyTestDummy;
#endif

        bool canMove = false;

        IEnemyMediator _mediator;

        public void SetTarget(Transform player) =>
            _mediator.SetTarget(player);

        public void Configure(IEnemyMediator mediator)
        {
            _mediator = mediator;
        }

        protected override void OnUpdate()
        {
            if (!isEnemyTestDummy)
            {
                _mediator.GetTarget();
            }

#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.F3))
                DoRecycle();
#endif
        }

        protected override void OnFixedUpdate()
        {
            if (isEnemyTestDummy) return;

            if (canMove)
                _mediator.DoMove();
        }

        public void DoRecycle()
        {
            GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
            canMove = false;

            Recycle();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (isEnemyTestDummy || collision.gameObject.CompareTag("Enemy")) return;

            if (collision.gameObject.CompareTag("Floor"))
            {
                if(!canMove)
                {
                    GetComponent<Rigidbody>().constraints |= RigidbodyConstraints.FreezePositionY;
                    canMove = true;
                }

                return;
            }

            _mediator.DoBooster(collision.gameObject.transform);
        }
    }
}