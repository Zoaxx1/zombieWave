using Assets.Scripts.Interfaces.IPlayer;
using UnityEngine;

namespace Assets.Scripts.Player.Attack
{
    public class PlayerAttacker : MonoBehaviour
    {
        IPlayerMediator _mediator;
        IPlayerInputAttack _playerInputAttack;

        public void Configure(IPlayerMediator mediator)
        {
            _mediator = mediator;

            _playerInputAttack = new PlayerAttackMouse();
        }

        public void Attack()
        {
            if (_playerInputAttack.CanShootFireOne())
                _mediator.DoShootFireOne();

            if(_playerInputAttack.CanShootFireTwo())
                _mediator.DoShootFireTwo();
        }
    }
}