using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Services
{
    public class Service
    {
        private static Service _instance;

        private readonly Dictionary<Type, object> _services;

        public Service()
        {
            _instance = this;
            _services = new Dictionary<Type, object>();
        }

        public static Service Instance => _instance ?? new Service();

        private Type GetType<T>()
        {
            return typeof(T);
        }

        private void AddService<T>(T service)
        {
            if (_services.TryGetValue(service.GetType(), out var serviceInstance)) return;
            _services.Add(GetType<T>(), service);
        }

        public void RemoveService<T>()
        {
            _services.Remove(GetType<T>());
        }

        public T GetService<T>()
        {
            if (!_services.TryGetValue(typeof(T), out var service))
            {
                var newService = CreateService<T>(GetType<T>());
                AddService(newService);

                return newService;
            }

            return (T)service;
        }

        private T CreateService<T>(Type type)
        {
            var t = (T)Activator.CreateInstance(type);
            return t;
        }
    }
}