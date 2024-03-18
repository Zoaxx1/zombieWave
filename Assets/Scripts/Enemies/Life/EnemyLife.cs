using Assets.Scripts.Interfaces.IEnemy;
using UnityEngine;

namespace Assets.Scripts.Enemies.Life
{
    public class EnemyLife : MonoBehaviour
    {
        [SerializeField] private float life;

        IEnemyMediator _mediator;

        public void Configure(IEnemyMediator mediator) =>
            _mediator = mediator;

        public void LessLife()
        {
            life--;

            if(life <= 0 )
                _mediator.LifeZero();
        }
    }
}