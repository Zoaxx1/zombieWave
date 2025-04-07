using Assets.Scripts.ObjectPools;
using Assets.Scripts.Enemies.Life;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player.Attack
{
    public class Grenade : RecyclableObject
    {
        public AmmunitionIds ID = AmmunitionIds.Grenade;
        
        [Header("Movement Settings")]
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float throwForce = 15f;
        [SerializeField] private float upwardForce = 5f;
        [SerializeField] private float explosionDelay = 3f;
        [SerializeField] private int maxBounces = 3;

        [Header("Explosion Settings")]
        [SerializeField] private float explosionRadius = 5f;
        [SerializeField] private float explosionDamage = 50f;
        [SerializeField] private LayerMask damageableLayers;
        [SerializeField] private ParticleSystem explosionEffect;

        private int currentBounces = 0;
        private bool hasExploded = false;

        public void Configure(Vector3 direction)
        {
            currentBounces = 0;
            hasExploded = false;
            
            // Aplicar fuerza inicial
            rb.velocity = direction * throwForce + Vector3.up * upwardForce;
            
            StartCoroutine(ExplosionCountdown());
        }

        private IEnumerator ExplosionCountdown()
        {
            yield return new WaitForSeconds(explosionDelay);
            Explode();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (hasExploded) return;

            currentBounces++;
            
            // Rebote con física (el Rigidbody y el Collider se encargan)
            
            if (currentBounces >= maxBounces)
            {
                Explode();
            }
        }

        private void Explode()
        {
            if (hasExploded) return;
            hasExploded = true;
            
            // Mostrar efecto de explosión
            if (explosionEffect != null)
            {
                ParticleSystem explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                explosion.Play();
                Destroy(explosion.gameObject, explosion.main.duration);
            }

            // Aplicar daño en área
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius, damageableLayers);
            foreach (var hitCollider in hitColliders)
            {
                // Aquí deberías tener tu sistema de daño
                IDamageable damageable = hitCollider.GetComponent<IDamageable>();
                damageable?.TakeDamage(explosionDamage);
                
                // Opcional: Aplicar fuerza de explosión
                Rigidbody rb = hitCollider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionDamage * 10f, transform.position, explosionRadius);
                }
            }

            // Reciclar el objeto
            Recycle();
        }

        // Opcional: Dibujar el radio de explosión en el editor
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, explosionRadius);
        }

        protected override void OnFixedUpdate()
        {
            // La física se maneja con el Rigidbody
        }

        protected override void OnUpdate() { }
    }
}