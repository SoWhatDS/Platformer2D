using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Utils
{
    internal sealed class ViewServices : IViewServices
    {
        private readonly Dictionary<string, ObjectPool> _viewCache = new Dictionary<string, ObjectPool>();
        private readonly Transform _rootForAllPoolObjects = new GameObject("PoolObjects").transform;

        public T Instantiate<T>(GameObject prefab, Vector3 spawnPoint)
        {
            if (!_viewCache.TryGetValue(prefab.name, out ObjectPool viewPool))
            {
                viewPool = new ObjectPool(prefab,_rootForAllPoolObjects);
                _viewCache[prefab.name] = viewPool;
            }

            if (viewPool.Pop(prefab, spawnPoint).TryGetComponent(out T component))
            {
                return component;
            }

            throw new InvalidOperationException($"{typeof(T)} not found");
        }

        public T InstantiateInCanvasUI<T>(GameObject prefab, Vector3 spawnPoint,Transform canvas)
        {
            if (!_viewCache.TryGetValue(prefab.name, out ObjectPool viewPool))
            {
                viewPool = new ObjectPool(prefab,_rootForAllPoolObjects);
                _viewCache[prefab.name] = viewPool;
            }

            if (viewPool.PopInCanvasUI(prefab, spawnPoint,canvas).TryGetComponent(out T component))
            {
                return component;
            }

            throw new InvalidOperationException($"{typeof(T)} not found");
        }

        public void Destroy(GameObject value)
        {
            _viewCache[value.name].Push(value);
        }
    }
}