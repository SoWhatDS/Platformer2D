using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2d.Utils;
using JoostenProductions;
using Cinemachine;
using Platformer2d.Engine.Game.Player;

namespace Platformer2d.Engine.BackGround
{
    internal sealed class BackGroundController : BaseController
    {
        private BackGroundView _backGroundView;
        private CinemachineVirtualCamera _cameraCinemachine;
        private Transform _playerTransform;
        private Camera _mainCamera;
        private ParallaxEffect _parallaxEffect;

        public BackGroundController(BackGroundView backGroundView)
        {
            _backGroundView = backGroundView;
            _cameraCinemachine = Object.FindAnyObjectByType<CinemachineVirtualCamera>();
            _playerTransform = Object.FindAnyObjectByType<PlayerView>().transform;
            _cameraCinemachine.Follow = _playerTransform;
            _mainCamera = Object.FindAnyObjectByType<Camera>();

            _parallaxEffect = new ParallaxEffect(_mainCamera,_backGroundView);

            UpdateManager.SubscribeToLateUpdate(LateUpdate);

        }

        private void LateUpdate()
        {
            _parallaxEffect.ParallaxEffectBackGround();        
        }

        protected override void OnDispose()
        {
            UpdateManager.UnsubscribeFromLateUpdate(LateUpdate);
        }
    }
}
