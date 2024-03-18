using Assets.Scripts.Interfaces.IPlayer;
using UnityEngine;

namespace Assets.Scripts.Player.Rotation
{
    public class PlayerRotator : MonoBehaviour
    {
        IPlayerInputRotator _playerRotation;

        public void Configure(PlayerInputs input)
        {
            switch (input)
            {
                case PlayerInputs.Mobile: break;
                case PlayerInputs.Joystick: break;
                default:
                    _playerRotation = new PlayerRotatorMouse();
                    break;
            }
        }

        public void Rotate() =>
            _playerRotation.Rotate(transform);
    }
}