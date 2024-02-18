using System.Collections;
using System.Collections.Generic;
using Platformer2d.Engine.Game.UI;
using Platformer2d.Engine.Game.UnitSound;
using UnityEngine;

namespace Platformer2d.Engine.Game.Enemy
{
    internal sealed class FlyingEye 
    {
        private FlyingEyeView _flyingEyeView;
        private FlyingEyeModel _flyingEyeModel;
        private DamageableUnit _damageableUnit;
        private RigidbodyWaypointsMove _rigidbodyWaypointsMove;
        private UnitGameSound _unitGameSound;

        private int _countWayPoints;
        private Transform _startRespawnPoint;
        private List<Transform> _wayPoints;

        public FlyingEye(FlyingEyeView flyingEyeView,FlyingEyeModel flyingEyeModel,UIGameModel uiGameModel,Transform startRespawnPoint)
        {
            _countWayPoints = startRespawnPoint.childCount;
            _startRespawnPoint = startRespawnPoint;
            _wayPoints = new List<Transform>(_countWayPoints);
            GetWayPoints();

            _flyingEyeView = flyingEyeView;
            _flyingEyeModel = flyingEyeModel;
            _damageableUnit = new DamageableUnit(_flyingEyeModel.Health,_flyingEyeModel.MaxHealth,
                _flyingEyeModel.InvicibilityTime,_flyingEyeView.Animator,_flyingEyeView.Rigidbody,uiGameModel);
            _rigidbodyWaypointsMove = new RigidbodyWaypointsMove(_flyingEyeView,_wayPoints);
            _flyingEyeView.Init(_damageableUnit);
            _flyingEyeView.BiteAttack.Init(_flyingEyeModel.AttackDamage,_flyingEyeModel.Knockback);
            _damageableUnit.OnDeath += OnDeath;
            _damageableUnit.OnHit += OnHit;
            _unitGameSound = new UnitGameSound(_flyingEyeView.AudioSource);
        }

        public void Fly()
        {
            if (_damageableUnit.IsAlive)
            {
                if (_flyingEyeView.CanMove)
                {
                    _rigidbodyWaypointsMove.RigidbodyMoveOnWaypoints(_flyingEyeModel.MoveSpeed);
                }
                else if (!_flyingEyeView.CanMove)
                {
                    _rigidbodyWaypointsMove.RigidbodyMoveOnWaypoints(_flyingEyeModel.IdleSpeed);
                }
            }
        }

        public void HitTimer()
        {
            _flyingEyeView.HitTimer();
        }

        public void CheckHasTarget(bool hasCollision)
        {
            _flyingEyeView.HasTarget = hasCollision;
        }

        private void OnDeath()
        {
            _flyingEyeView.Rigidbody.gravityScale = 2f;
            _flyingEyeView.Rigidbody.velocity = new Vector2(0, _flyingEyeView.Rigidbody.velocity.y);
            _flyingEyeView.DeathCollider.enabled = true;
            _unitGameSound.PlayOneShotSound(_flyingEyeModel.DeathAudioClip);
        }

        private void OnHit()
        {
            _unitGameSound.PlayOneShotSound(_flyingEyeModel.HitAudioClip);
        }

        public void UnSubscribeOnAction()
        {
            _damageableUnit.OnDeath -= OnDeath;
            _damageableUnit.OnHit -= OnHit;
        }

        private void GetWayPoints()
        {
            for (int i = 0; i < _countWayPoints; i++)
            {
                _wayPoints.Add(_startRespawnPoint.GetChild(i));
            }
        }
    }
}
