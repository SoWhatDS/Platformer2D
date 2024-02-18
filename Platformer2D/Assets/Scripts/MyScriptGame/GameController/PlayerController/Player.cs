using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2d.Utils;
using UnityEngine.Events;
using Platformer2d.Engine.Game.UI;
using Platformer2d.Engine.Sound;
using Platformer2d.Engine.Game.UnitSound;

namespace Platformer2d.Engine.Game.Player
{
    internal sealed class Player 
    {
        private PlayerView _playerView;
        private PlayerModel _playerModel;

        private IMoveRigidbodyPlayer _playerMovement;
        private TouchingDirection _touchingDirection;
        private DamageableUnit _damageableUnit;
        private RangedAttack _rangedAttack;
        private UnitGameSound _unitGameSound;
        private UIGameModel _uiGameModel;
        private PlayerManagerModel _playerManagerModel;
        private TakeCoinsUnit _takeCoinsUnit;
        
        public float CurrentMoveSpeed
        {
            get
            {
                if (_playerView.CanMove)
                {
                    if (_playerView.IsMoving && !_touchingDirection.IsOnWall)
                    {
                        if (_touchingDirection.IsGrounded)
                        {
                            if (_playerView.IsRunning)
                            {
                                return _playerModel.RunSpeed;
                            }
                            else
                            {
                                return _playerModel.WalkSpeed;
                            }
                        }
                        else
                        {
                            return _playerModel.AirWalkSpeed;
                        }
                    }
                    else
                    {
                        return _playerModel.IdleSpeed;
                    }
                }
                else
                {
                    return _playerModel.IdleSpeed;
                }
            
            }
        }

        public Player(PlayerView playerView, PlayerModel playerModel,UIGameModel uiGameModel,IViewServices viewServices,PlayerManagerModel playerManagerModel)
        {
            _playerView = playerView;
            _playerModel = playerModel;
            _uiGameModel = uiGameModel;
            _playerManagerModel = playerManagerModel;
            _playerMovement = new PlayerMovement(_playerView.PlayerRigidbody);
            _touchingDirection = new TouchingDirection(_playerView.PlayerCollider,_playerView.PlayerAnimator,_playerView.ContactFilter);
            _damageableUnit = new DamageableUnit(_playerModel.Health,_playerModel.MaxHealth,_playerModel.InvicibilityTime,_playerView.PlayerAnimator,_playerView.PlayerRigidbody,uiGameModel);
            _rangedAttack = new RangedAttack(viewServices, _playerModel);
            _unitGameSound = new UnitGameSound(_playerView.AudioSourceAttack);
            _takeCoinsUnit = new TakeCoinsUnit(_playerModel.CoinsCount, _uiGameModel);
            _playerView.Init(_damageableUnit,_rangedAttack,_takeCoinsUnit);
            _playerView.AttackCollider1.Init(_playerModel.AttackDamage, _playerModel.KnockBack);
            _playerView.AttackCollider2.Init(_playerModel.AttackDamage2, _playerModel.KnockBack2);
            _playerView.AttackCollider3.Init(_playerModel.AttackDamage3, _playerModel.KnockBack3);
            _playerView.AirAttack1Collider.Init(_playerModel.AirAttackDamage1, _playerModel.AirKnockback1);
            _playerView.AirAttack2Collider.Init(_playerModel.AirAttackDamage2, _playerModel.AirKnockback2);

            SubscribeOnAction();
        }
       
        public void RigidbodyPlayerMove()
        {
            if (_playerView.IsAlive && !_damageableUnit.LockVelocity)
            {
                _playerMovement.RigidbodyMove(_playerView.MoveInput, CurrentMoveSpeed);
            }
            else
            {
                _playerView.IsMoving = false;
            }
        }

        public void RigidbodyPlayerJump()
        {
            _playerView.PlayerAnimator.SetFloat(GameConstantsForAnimation.yVelocity, _playerView.PlayerRigidbody.velocity.y);

            if (_playerView.IsJumping && _touchingDirection.IsGrounded && _playerView.CanMove)
            {
                _playerMovement.RigidbodyJump(_playerModel.JumpImpulse);
            }
        }

        public void CheckTouchingDirections()
        {
            _touchingDirection.CheckTouching();
        }

        public void HitTimer()
        {
            _playerView.HitTimer();
        }

        public void MoveArrow()
        {
            _rangedAttack.MoveArrow();
        }

        public void UnSubscribeOnAction()
        {
            _damageableUnit.OnDeath -= Death;
            _damageableUnit.OnHit -= Hit;
            _damageableUnit.OnHeal -= Heal;
            _rangedAttack.OnBowAttack -= BowAttack;
            _playerView.OnAttackPlayer -= Attack;
        }

        private void SubscribeOnAction()
        {
            _damageableUnit.OnDeath += Death;
            _damageableUnit.OnHit += Hit;
            _damageableUnit.OnHeal += Heal;
            _rangedAttack.OnBowAttack += BowAttack;
            _playerView.OnAttackPlayer += Attack;
        }

        private void Attack()
        {
            _unitGameSound.PlayOneShotSound(_playerModel.AttackAudioClip);
        }

        private void Hit()
        {
            _unitGameSound.PlayOneShotSound(_playerModel.HitAudioClip);
            _uiGameModel.OnChangeHealthUI?.Invoke(_damageableUnit.Health,_damageableUnit.MaxHealth);
            
        }

        private void Death()
        {
            _unitGameSound.PlayOneShotSound(_playerModel.DeathAudioClip);
            _playerManagerModel.OnGameOver.Invoke(_damageableUnit.Health <= 0);
        }

        private void BowAttack()
        {
            _unitGameSound.PlayOneShotSound(_playerModel.BowAttackAudioClip);
        }

        private void Heal()
        {
            _uiGameModel.OnChangeHealthUI?.Invoke(_damageableUnit.Health, _damageableUnit.MaxHealth);
            _unitGameSound.PlayOneShotSound(_playerModel.HealAudioClip);
        }
    }
}
