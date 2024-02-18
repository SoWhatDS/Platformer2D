using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Platformer2d.Utils
{
    internal sealed class ObjectPool : IDisposable
    {
        private readonly Stack<GameObject> _stack = new Stack<GameObject>();
        private readonly GameObject _prefab;
        private readonly Transform _root;

        public ObjectPool(GameObject prefab)
        {
            _prefab = prefab;
            _root = new GameObject($"[{_prefab.name}]").transform;
        }

        public ObjectPool(GameObject prefab,Transform _rootForAllPoolObjects)
        {
            _prefab = prefab;
            _root = new GameObject($"[{_prefab.name}]").transform;
            _root.SetParent(_rootForAllPoolObjects);
        }

        public GameObject Pop(GameObject prefab,Vector3 spawnPoint)
        {
            GameObject go;
            if (_stack.Count == 0)
            {
                go = Object.Instantiate(prefab, spawnPoint, Quaternion.identity);
                go.name = prefab.name;
            }
            else
            {
                go = _stack.Pop();
                go.transform.position = spawnPoint;
            }
            go.SetActive(true);
            go.transform.SetParent(null);
            return go;
        }

        public GameObject PopInCanvasUI(GameObject prefab, Vector3 spawnPoint,Transform canvas)
        {
            GameObject go;
            if (_stack.Count == 0)
            {
                go = Object.Instantiate(prefab, spawnPoint, Quaternion.identity);
                go.name = prefab.name;
            }
            else
            {
                go = _stack.Pop();
                go.transform.position = spawnPoint;
            }
            go.SetActive(true);
            go.transform.SetParent(canvas);
            return go;
        }

        public void Push(GameObject go)
        {
            _stack.Push(go);
            go.transform.SetParent(_root);
            go.SetActive(false);
        }


        public void Dispose()
        {
            for (int i = 0; i < _stack.Count; i++)
            {
                var gameobject = _stack.Pop();
                Object.Destroy(gameobject);
            }
            Object.Destroy(_root.gameObject);
        }
    }
}
