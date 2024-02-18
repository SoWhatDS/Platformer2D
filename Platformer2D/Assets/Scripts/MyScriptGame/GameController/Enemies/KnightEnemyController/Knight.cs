using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2d.Utils;
using Platformer2d.Engine.Game.UI;
using Platformer2d.Engine.Game.UnitSound;

namespace Platformer2d.Engine.Game.Enemy
{
    internal sealed class Knight
    {
        private EnemyView _knightView;
        private EnemyModel _knightModel;
        private TouchingDirection _touchingDirection;
        private DamageableUnit _damageableUnit;
        private UnitGameSound _unitGameSound;

        public float AttackCooldown
        {
            get { return _knightView.Animator.GetFloat(GameConstantsForAnimation.AttackCooldown); }
            set { _knightView.Animator.SetFloat(GameConstantsForAnimation.AttackCooldown,value); }
        }

        public Knight(EnemyView knightView,EnemyModel knightModel,UIGameModel uiGameModel)
        {
            _knightView = knightView;
            _knightModel = knightModel;
            _touchingDirection = new TouchingDirection(_knightView.Collider,_knightView.Animator,_knightView.ContactFilter);
            _damageableUnit = new DamageableUnit(_knightModel.Health,_knightModel.MaxHealth,_knightModel.InvicibilityTime,_knightView.Animator,_knightView.Rigidbody,uiGameModel);
            _knightView.Init(_damageableUnit,uiGameModel);
            _knightView.AttackCollider.Init(_knightModel.AttackDamage, _knightModel.KnockBack);
            _damageableUnit.OnDeath += Death;
            _damageableUnit.OnHit += Hit;
            _unitGameSound = new UnitGameSound(_knightView.AudioSource);
            
        }

        public void RigidbodyMove()
        {
            if (_touchingDirection.IsGrounded)
            {
                if (_touchingDirection.IsOnWall || !_knightView.HasClifDetectionZone)
                {
                    FlipDirection();
                }
            }

            if (!_damageableUnit.LockVelocity)
            {
                if (_knightView.CanMove && _touchingDirection.IsGrounded)
                {
                    _knightView.Rigidbody.velocity = new Vector2(_knightModel.WalkSpeed * _knightView.WalkDirectionVector.x, _knightView.Rigidbody.velocity.y);
                }
                else
                {
                    _knightView.Rigidbody.velocity = new Vector2(Mathf.Lerp(_knightView.Rigidbody.velocity.x, _knightModel.WalkIdle, _knightModel.WalkStopRate),
                        _knightView.Rigidbody.velocity.y);
                }
            }
        }

        private void FlipDirection()
        {
            if (_knightView.WalkDirection == EnemyView.WalkableDirection.Right)
            {
                _knightView.WalkDirection = EnemyView.WalkableDirection.Left;
            }
            else if (_knightView.WalkDirection == EnemyView.WalkableDirection.Left)
            {
                _knightView.WalkDirection = EnemyView.WalkableDirection.Right;
            }
            else
            {
                Debug.Log("Current walkable direction is not set to legal values of right or left");
            }
        }

        public void CheckTouchingDirection()
        {
            _touchingDirection.CheckTouching();
        }

        public void HitTimer()
        {
            _knightView.HitTimer();
        }

        public void AttackCooldownTimer()
        {
            if (AttackCooldown > 0)
            {
                AttackCooldown -= Time.deltaTime;
            }
        }

        public void CheckClifCollission(bool hasCollision)
        {
            _knightView.HasClifDetectionZone = hasCollision;
        }

        public void CheckHasTarget(bool hasCollision)
        {
            _knightView.HasTarget = hasCollision;
        }

        public void UnSubscribeOnAction()
        {
            _damageableUnit.OnDeath -= Death;
            _damageableUnit.OnHit -= Hit;
        }

        private void Death()
        {
            _unitGameSound.PlayOneShotSound(_knightModel.DeathAudioClip);
        }

        private void Hit()
        {
            _unitGameSound.PlayOneShotSound(_knightModel.HitAudioClip);
        }
    }
}
