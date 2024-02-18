using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2d.Utils;
using JoostenProductions;
using Platformer2d.Engine.Game.UI;

namespace Platformer2d.Engine.Game.Enemy
{
    internal sealed class KnightEnemyController : BaseController,IEnemyController
    {
        private EnemyView _knightView;
        private EnemyModel _knightModel;
        private Knight _knight;
        private UIGameModel _uiGameModel;
        private Transform _startRespawnPoint;

        public KnightEnemyController(EnemyModel knightModel,UIGameModel uiGameModel,Transform startRespawnPoint)
        {
            _startRespawnPoint = startRespawnPoint;
            _knightModel = knightModel;
            _knightView = LoadView();
            _knight = new Knight(_knightView,_knightModel,uiGameModel);
            _knightView.DetectionZoneTarget.OnCollisionDetected += CheckHasTarget;
            _knightView.ClifDetectionZone.OnCollisionDetected += CheckHasClifZone;
            UpdateManager.SubscribeToFixedUpdate(FixedUpdate);
            UpdateManager.SubscribeToUpdate(Update);
        }

        private EnemyView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(GameConstantsView.KnightView);
            GameObject objectView = Object.Instantiate(prefab,_startRespawnPoint);
            AddGameObjects(objectView);
            return ResourceLoader.GetOrAddComponent<EnemyView>(objectView);

        }

        private void FixedUpdate()
        {
            if (_knightView == null)
            {
                return;
            }
            KnightRigidbodyMove();
            CheckTouchingDirection();
        }

        private void Update()
        {
            if (_knightView == null)
            {
                return;
            }
            HitTimer();
            AttackCooldownTimer();
        }

        private void KnightRigidbodyMove()
        {
            _knight.RigidbodyMove();
        }

        private void CheckTouchingDirection()
        {
            _knight.CheckTouchingDirection();
        }

        private void HitTimer()
        {
            _knight.HitTimer();
        }

        private void AttackCooldownTimer()
        {
            _knight.AttackCooldownTimer();
        }

        private void CheckHasClifZone(bool hasClifZone)
        {
            _knight.CheckClifCollission(hasClifZone);
        }

        private void CheckHasTarget(bool hasTarget)
        {
            _knight.CheckHasTarget(hasTarget);
        }

        protected override void OnDispose()
        {
            _knight.UnSubscribeOnAction();
            _knightView.DetectionZoneTarget.OnCollisionDetected -= CheckHasTarget;
            _knightView.ClifDetectionZone.OnCollisionDetected -= CheckHasClifZone;
            UpdateManager.UnsubscribeFromFixedUpdate(FixedUpdate);
            UpdateManager.UnsubscribeFromUpdate(Update);
        }
    }
}
