using Assets.Scripts.Interfaces.IEnemy;
using UnityEngine;

namespace Assets.Scripts.Enemies.Life
{
    public class EnemyLife : MonoBehaviour, IDamageable
    {
        [SerializeField] private float life;
        [SerializeField] private MeshRenderer meshRenderer;
        
        IEnemyMediator _mediator;

        public void Configure(IEnemyMediator mediator) =>
            _mediator = mediator;

        public void TakeDamage(float damage)
        {
            life -= damage;
            meshRenderer.material.color = Color.red;
            Debug.Log(life);
            Debug.Log("AY");
            
            
            if(life <= 0 )
                _mediator.LifeZero();
        }
    }
}