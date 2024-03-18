using Assets.Scripts.Services;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player.Attack
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] List<Ammunition> ammunitions;

        [SerializeField] Transform shootPosition;

        ShooterFactoryService shooter;

        void Start()
        {
            shooter = Service.Instance.GetService<ShooterFactoryService>();

            foreach (var ammunition in ammunitions)
                shooter.CreateObjectPool(ammunition.ID, ammunition);
        }

        public void ShootFireOne() =>
            shooter.Shoot(shootPosition, AmmunitionIds.Bullet);

        public void ShootFireTwo() =>
            shooter.Shoot(shootPosition, AmmunitionIds.Granade);

        /* private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
            
            }
        }*/

}
}
