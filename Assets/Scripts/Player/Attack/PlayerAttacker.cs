using Assets.Scripts.Interfaces.IPlayer;
using UnityEngine;

namespace Assets.Scripts.Player.Attack
{
    public class PlayerAttacker : MonoBehaviour
    {
        IPlayerMediator _mediator;
        IPlayerInputAttack _playerInputAttack;

        public void Configure(IPlayerMediator mediator, PlayerInputs input)
        {
            _mediator = mediator;

            switch (input)
            {
                case PlayerInputs.Mobile: break;
                case PlayerInputs.Joystick: break;
                default:
                    _playerInputAttack = new PlayerAttackMouse();
                    break;
            }
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