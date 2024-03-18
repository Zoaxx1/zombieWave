using Assets.Scripts.ObjectPools;
using Assets.Scripts.Player.Attack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Services
{
    public class ShooterFactoryService
    {
        Dictionary <AmmunitionIds, ObjectPool> _objectPools;

        public ShooterFactoryService() =>
            _objectPools = new Dictionary<AmmunitionIds, ObjectPool>();

        public void CreateObjectPool(AmmunitionIds id, RecyclableObject ammunition)
        {
            var objectPool = new ObjectPool(ammunition);

            _objectPools.Add(id, objectPool);
        }

        public void Shoot(Transform spawnTransform, AmmunitionIds id)
        {
            var ammounition = _objectPools[id].Instantiate(spawnTransform.position, spawnTransform.rotation);

            ammounition.GetComponent<Ammunition>().Configure(spawnTransform.right * -1);
        }
    }
}