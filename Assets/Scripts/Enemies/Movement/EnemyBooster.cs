using UnityEngine;

namespace Assets.Scripts.Enemies.Movement
{
    public class EnemyBooster : MonoBehaviour
    {
        [SerializeField] Rigidbody rb;
        [SerializeField] float impulseForce;
        
        public void Impulse(Transform collisionPosition)
        {
            Vector3 outForThePlayer = ((transform.position - collisionPosition.position));
            rb.AddForce(outForThePlayer * impulseForce, ForceMode.Impulse);
        }
    }
}