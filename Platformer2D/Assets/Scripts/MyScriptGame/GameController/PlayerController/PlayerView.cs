using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Platformer2d.Utils;
using System;
using UnityEngine.Events;
using Platformer2d.Engine.Game.UI;
using Platformer2d.Engine.Game.UnitSound;

namespace Platformer2d.Engine.Game.Player
{
    [RequireComponent(typeof(Animator), typeof(Rigidbody2D),typeof(Collider2D))]
    internal class PlayerView : MonoBehaviour,IDamageableUnit,IHealUnit,ITakeCoins
    {
        [field: SerializeField] public SpriteRenderer PlayerSpriteRenderer;
        [field: SerializeField] public Rigidbody2D PlayerRigidbody;
        [field: SerializeField] public Collider2D PlayerCollider;
        [field: SerializeField] public Animator PlayerAnimator;
        [field: SerializeField] public ContactFilter2D ContactFilter;
        [field: SerializeField] public Attack AttackCollider1;
        [field: SerializeField] public Attack AttackCollider2;
        [field: SerializeField] public Attack AttackCollider3;
        [field: SerializeField] public Transform FirePointForArrow;
        [field: SerializeField] public Attack AirAttack1Collider;
        [field: SerializeField] public Attack AirAttack2Collider;
        [field: SerializeField] public AudioSource AudioSourceAttack;

        private bool _isMoving;
        private bool _isRunning;
        private bool _isJumping;
        private Vector2 _moveInput;
        private IDamageableUnit _damageableUnit;
        private RangedAttack _rangedAttack;
        private ITakeCoins _takeCoins;

        public UnityAction OnAttackPlayer;

        public bool IsMoving
        {
            get
            {
                return _isMoving;
            }
            set
            {
                _isMoving = value;
                PlayerAnimator.SetBool(GameConstantsForAnimation.IsMoving,value);
            }
        }

        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
            set
            {
                _isRunning = value;
                PlayerAnimator.SetBool(GameConstantsForAnimation.IsRunning,value);
            }
        }

        public bool IsJumping
        {
            get
            {
                return _isJumping;
            }
            private set { }
        }

        public bool CanMove
        {
            get
            {
                return PlayerAnimator.GetBool(GameConstantsForAnimation.CanMove);
            }
            
        }

        public bool IsAlive
        {
            get {return PlayerAnimator.GetBool(GameConstantsForAnimation.IsAlive); }
        }

        public Vector2 MoveInput
        {
            get => _moveInput;

            private set { }
        }

        public void OnRigidbodyMove(InputAction.CallbackContext context)
        {
            _moveInput.x = context.ReadValue<Vector2>().x;

            IsMoving = _moveInput != Vector2.zero;
        }

        public void OnRun(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                IsRunning = true;
            }
            else if(context.canceled)
            {
                IsRunning = false;
            }
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _isJumping = true;
                PlayerAnimator.SetTrigger(GameConstantsForAnimation.JumpTrigger);
            }
            else if (context.canceled)
            {
                _isJumping = false;
            }
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                PlayerAnimator.SetTrigger(GameConstantsForAnimation.AttackTrigger);
                OnAttackPlayer?.Invoke();
            }
        }

        public void OnBowAttack(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                PlayerAnimator.SetTrigger(GameConstantsForAnimation.RangedAttackTrigger);
            }
        }

        public bool Hit(int damage, Vector2 knockback)
        {
           return _damageableUnit.Hit(damage, knockback);
        }

        public void HitTimer()
        {
            _damageableUnit.HitTimer();
            
        }

        public void Init(IDamageableUnit damageableUnit,RangedAttack rangedAttack,ITakeCoins takeCoins)
        {
            _damageableUnit = damageableUnit;
            _rangedAttack = rangedAttack;
            _takeCoins = takeCoins;
        }

        public bool Heal(int healthRestore)
        {
            if (_damageableUnit is IHealUnit healUnit)
            {
                return healUnit.Heal(healthRestore);
            }
            return false;
        }

        public void BowAttack()
        {
            Vector3 direction = new Vector3(FirePointForArrow.transform.localScale.x * transform.localScale.x > 0 ? 1 : -1,
                FirePointForArrow.transform.localScale.y, FirePointForArrow.transform.localScale.z);
            _rangedAttack.CreateArrow(FirePointForArrow.transform.position, direction);
        }

        public void TakeCoin()
        {
            _takeCoins.TakeCoin();
        }
    }
}