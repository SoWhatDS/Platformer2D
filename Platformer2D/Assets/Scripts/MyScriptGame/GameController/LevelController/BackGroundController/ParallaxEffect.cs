using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using JoostenProductions;
using Platformer2d.Engine.Game.Player;
using UnityEngine;

namespace Platformer2d.Engine.BackGround
{
    internal sealed class ParallaxEffect : IParallaxEffect
    {
        private Transform _mainCamera;
        private Vector3 _cameraStartPosition;
        private float _distance;

        private GameObject[] _backGroundsChildPrefabs;
        private Material[] _materialsBackGround;
        private float[] _backGroundsSpeed;
        private float _farthestBack;

        public float parallaxSpeed;

        private BackGroundView _backGroundView;


        internal ParallaxEffect(Camera mainCamera,BackGroundView backGroundView)
        {
            _mainCamera = mainCamera.transform;
            _cameraStartPosition = _mainCamera.position;
            _backGroundView = backGroundView;
            _backGroundsChildPrefabs = _backGroundView.ChildBackGroundsPrefabs;
            _materialsBackGround = new Material[_backGroundsChildPrefabs.Length];
            _backGroundsSpeed = new float[_backGroundsChildPrefabs.Length];

            GetMaterialsBackGrounds(_backGroundsChildPrefabs.Length);
            BackSpeedCalculate(_backGroundsChildPrefabs.Length);
        }

        private void GetMaterialsBackGrounds(int backGroundCount)
        {

            for (int i = 0; i < backGroundCount; i++)
            {
                _materialsBackGround[i] = _backGroundView.ChildBackGroundRenderers[i].material;
            }
        }

        private void BackSpeedCalculate(int backGroundCount)
        {
            for (int i = 0; i < backGroundCount; i++)
            {
                if ((_backGroundsChildPrefabs[i].transform.position.z - _mainCamera.position.z) > _farthestBack)
                {
                    _farthestBack = _backGroundsChildPrefabs[i].transform.position.z - _mainCamera.position.z;
                }
            }

            for (int i = 0; i < backGroundCount; i++)
            {
                _backGroundsSpeed[i] = 1 - (_backGroundsChildPrefabs[i].transform.position.z - _mainCamera.position.z) / _farthestBack;
            }
        }

        public void ParallaxEffectBackGround()
        {
            _distance = _mainCamera.position.x - _cameraStartPosition.x;

            _backGroundView.transform.position = new Vector3(_mainCamera.position.x, _backGroundView.transform.position.y, 0);

            for (int i = 0; i < _backGroundsChildPrefabs.Length; i++)
            {
                float speed = _backGroundsSpeed[i] * _backGroundView.ParallaxSpeed;
                _materialsBackGround[i].SetTextureOffset("_MainTex", new Vector2(_distance, 0) * speed);
            }

        }
    }
}
