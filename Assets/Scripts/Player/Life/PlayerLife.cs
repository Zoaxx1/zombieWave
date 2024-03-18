using Assets.Scripts.Interfaces.IPlayer;
using UnityEngine;

namespace Assets.Scripts.Player.Life
{
    public class PlayerLife : MonoBehaviour
    {
        [SerializeField] float life;

        IPlayerMediator _mediator;

        public void Configure(IPlayerMediator mediator) =>
            _mediator = mediator;

        public void LifePlayer(int healthless)
        {
            life -= healthless;
            if (life <= 0)
            {
                _mediator.LifeZero();
            }
        }
    }
}