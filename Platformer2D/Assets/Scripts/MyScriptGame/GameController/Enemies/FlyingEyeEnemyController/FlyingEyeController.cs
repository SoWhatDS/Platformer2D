using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2d.Utils;
using JoostenProductions;
using Platformer2d.Engine.Game.UI;

namespace Platformer2d.Engine.Game.Enemy
{
    internal sealed class FlyingEyeController : BaseController,IEnemyController
    {
        private FlyingEyeView _flyingEyeView;
        private FlyingEyeModel _flyingEyeModel;
        private FlyingEye _flyingEye;
        private Transform _startRespawnPoint;

        public FlyingEyeController(FlyingEyeModel flyingEyeModel,UIGameModel uiGameModel,Transform startRespawnPoint)
        {
            _startRespawnPoint = startRespawnPoint;
            _flyingEyeView = LoadView();
            _flyingEyeModel = flyingEyeModel;
            _flyingEye = new FlyingEye(_flyingEyeView,_flyingEyeModel,uiGameModel,_startRespawnPoint);
            _flyingEyeView.DetectionZoneTarget.OnCollisionDetected += CheckHasTarget;
            UpdateManager.SubscribeToFixedUpdate(FixedUpdate);
            UpdateManager.SubscribeToUpdate(Update);
        }

        private void Update()
        {
            if (_flyingEyeView == null)
            {
                return;
            }
            HitTimer();
        }

        private void FixedUpdate()
        {
            if (_flyingEyeView == null)
            {
                return;
            }
            Fly();
        }

        private FlyingEyeView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(GameConstantsView.FlyingEyeView);
            GameObject objectView = Object.Instantiate(prefab, _startRespawnPoint);
            AddGameObjects(objectView);
            return ResourceLoader.GetOrAddComponent<FlyingEyeView>(objectView);
        }

        private void Fly()
        {
            _flyingEye.Fly();
        }

        private void HitTimer()
        {
            _flyingEye.HitTimer();
        }

        private void CheckHasTarget(bool hasCollision)
        {
            _flyingEye.CheckHasTarget(hasCollision);
        }

        protected override void OnDispose()
        {
            _flyingEye.UnSubscribeOnAction();
            _flyingEyeView.DetectionZoneTarget.OnCollisionDetected -= CheckHasTarget;
            UpdateManager.UnsubscribeFromUpdate(Update);
            UpdateManager.UnsubscribeFromFixedUpdate(FixedUpdate);             
        }
    }
}
