using Assets.Scripts.Interfaces.IPlayer;
using UnityEngine;

namespace Assets.Scripts.Player.Movement
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] Rigidbody rb;
        [SerializeField] float speed = 800;

        IPlayerInputMovement _playerInputMovement;

        public void Configure(PlayerInputs input)
        {
            switch (input)
            {
                case PlayerInputs.Mobile: break;
                case PlayerInputs.Joystick: break;
                default: 
                    _playerInputMovement = new PlayerInputKeyboard();
                    break;
            }
        }

        public void Move() =>
            rb.velocity = _playerInputMovement.GetInput() * speed * Time.deltaTime;
    }
}