using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.ObjectPools
{
    public class ObjectPool
    {
        readonly RecyclableObject _obj;
        readonly List<RecyclableObject> _objectsInstantiates;
        readonly List<RecyclableObject> _objectsRecycles;

        public ObjectPool(RecyclableObject obj)
        {
            _obj = obj;

            _objectsInstantiates = new List<RecyclableObject>();
            _objectsRecycles = new List<RecyclableObject>();

            AddToThePool();
        }

        RecyclableObject CreateObject()
        {
            var obj = Object.Instantiate(_obj, Vector3.zero, Quaternion.identity);
            obj.Configure(this);

            return obj;
        }

        void AddToThePool()
        {
            for(var i = 0; i < 5; i++)
                _objectsRecycles.Add(CreateObject());
        }

        public RecyclableObject Instantiate(Vector3 position, Quaternion rotation)
        {
            var obj = _obj;

            if(_objectsRecycles.Count == 0)
                obj = CreateObject();
            else
            {
                obj = _objectsRecycles[0];
                _objectsRecycles.RemoveAt(0);
            }

            obj.transform.position = position;
            obj.transform.rotation = rotation;

            _objectsInstantiates.Add(obj);

            obj.EnableObject();

            return obj;
        }

        public void Recycle()
        {
            var obj = _objectsInstantiates[0];

            _objectsInstantiates.RemoveAt(0);

            _objectsRecycles.Add(obj);

            obj.DisableObject();
        }

    }
}
