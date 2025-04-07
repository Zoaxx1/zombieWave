using Assets.Scripts.Interfaces.IPlayer;
using UnityEngine;

namespace Assets.Scripts.Player.Attack
{
    public class PlayerAttacker : MonoBehaviour
    {
        IPlayerMediator _mediator;

        public void Configure(IPlayerMediator mediator)
        {
            _mediator = mediator;
        }

        public void Attack()
        {
            if (Input.GetMouseButtonDown(0))
                _mediator.DoShootFireOne();

            if(Input.GetMouseButtonDown(1))
                _mediator.DoShootFireTwo();
        }
    }
}