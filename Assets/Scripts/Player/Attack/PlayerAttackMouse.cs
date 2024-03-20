using Assets.Scripts.Interfaces.IPlayer;
using UnityEngine;

namespace Assets.Scripts.Player.Attack
{
    public class PlayerAttackMouse : IPlayerInputAttack
    {
        public bool CanShootFireOne() =>
            false;
            // Input.GetMouseButtonDown(0);

        public bool CanShootFireTwo() =>
            false;
            // Input.GetMouseButtonDown(1);
    }
}