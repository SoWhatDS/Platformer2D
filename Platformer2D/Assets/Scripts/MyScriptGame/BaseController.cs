using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Platformer2d.Engine
{
    internal abstract class BaseController : IDisposable
    {
        private List<BaseController> _baseControllers;
        private List<GameObject> _gameobjects;
        private bool _isDisposed;

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _isDisposed = true;

            DisposeBaseControllers();
            DisposeGameObjects();

            OnDispose();
        }

        private void DisposeGameObjects()
        {
            if (_gameobjects == null)
            {
                return;
            }

            foreach (GameObject gameobject in _gameobjects)
            {
                Object.Destroy(gameobject);
            }

            _gameobjects.Clear();
        }

        private void DisposeBaseControllers()
        {
            if (_baseControllers == null)
            {
                return;
            }

            foreach (BaseController baseController in _baseControllers)
            {
                baseController.Dispose();
            }

            _baseControllers.Clear();
        }

        protected virtual void OnDispose() { }

        protected void AddControllers(BaseController controller)
        {
            _baseControllers ??= new List<BaseController>();
            _baseControllers.Add(controller);
        }

        protected void AddGameObjects(GameObject gameObject)
        {
            _gameobjects ??= new List<GameObject>();
            _gameobjects.Add(gameObject);
        }
    }
}
