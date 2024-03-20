using Assets.Scripts.Interfaces.IPlayer;
using Assets.Scripts.Player.Attack;
using Assets.Scripts.Player.Life;
using Assets.Scripts.Player.Movement;
using Assets.Scripts.Player.Rotation;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerMediator : MonoBehaviour, IPlayerMediator
    {
        [SerializeField] PlayerController player;
        [SerializeField] PlayerLife playerLife;
        [SerializeField] PlayerAttacker playerAttacker;
        [SerializeField] PlayerShooter playerShooter;

        private void Awake()
        {
            player.Configure(this);
            playerLife.Configure(this);
            playerAttacker.Configure(this);
        }

        public void LifeZero() =>
            player.DestroyPlayer();

        public void DoAttack() =>
            playerAttacker.Attack();

        public void DoShootFireOne() =>
            playerShooter.ShootFireOne();

        public void DoShootFireTwo() =>
            playerShooter.ShootFireTwo();
    }
}