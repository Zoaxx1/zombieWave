using Assets.Scripts.ObjectPools;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player.Attack
{
    public class Ammunition : RecyclableObject
    {
        public AmmunitionIds ID = AmmunitionIds.Bullet;
        [SerializeField] Rigidbody rb;
        [SerializeField] float speed;
        [SerializeField] float timeToDestroy;

        Vector3 _direction;

        public void Configure(Vector3 direction)
        {
            _direction = direction;

            StartCoroutine(DestroyBeforeTime());
        }

        IEnumerator DestroyBeforeTime()
        {
            yield return new WaitForSeconds(timeToDestroy);
            Recycle();
        }

        private void OnCollisionEnter(Collision collision)
        {
            Recycle();
        }

        protected override void OnFixedUpdate() =>
            rb.velocity = _direction * speed * Time.deltaTime;

        protected override void OnUpdate() { }
    }
}