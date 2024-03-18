using UnityEngine;

namespace Assets.Scripts.Enemies.Movement
{
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] Rigidbody rb;
        [SerializeField] float speed;
    
        Vector3 _direction;

        public void SetDirection(Vector3 direction) => _direction = direction;

        public void Move() =>
            rb.velocity = _direction * speed * Time.deltaTime;
    }
}