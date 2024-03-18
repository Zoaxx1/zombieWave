using System;
using UnityEngine;

namespace Assets.Scripts.ObjectPools
{
    public abstract class RecyclableObject : MonoBehaviour
    {
        ObjectPool _objectPool;

        public void Configure(ObjectPool objectPool) =>
            _objectPool = objectPool;

        void Update() =>
            OnUpdate();

        void FixedUpdate() =>
            OnFixedUpdate();

        protected abstract void OnFixedUpdate();

        protected abstract void OnUpdate();

        public void EnableObject() =>
            gameObject.SetActive(true);

        public void DisableObject() =>
            gameObject.SetActive(false);

        public void Recycle() =>
            _objectPool.Recycle();
    }
}