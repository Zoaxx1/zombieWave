using Assets.Scripts.Interfaces.IPlayer;
using UnityEngine;

namespace Assets.Scripts.Player.Movement
{
    public class PlayerInputKeyboard : IPlayerInputMovement
    {
        public Vector3 GetInput()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            return new Vector3(moveHorizontal, 0, moveVertical);
        }
    }
}