using Assets.Scripts.Services;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Scripts.Player.Attack
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] Ammunition ammunition;
        [SerializeField] Grenade grenade;

        [SerializeField] Transform shootPosition;

        ShooterFactoryService shooter;

        void Start()
        {
            shooter = Service.Instance.GetService<ShooterFactoryService>();
            shooter.CreateObjectPool(ammunition.ID, ammunition);
            shooter.CreateObjectPool(grenade.ID, grenade);
        }

        public void ShootFireOne() =>
            shooter.Shoot(shootPosition, AmmunitionIds.Bullet);

        public void ShootFireTwo() =>
            shooter.Shoot(shootPosition, AmmunitionIds.Grenade);

        /* private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {

            }
        }*/

    }
}
