using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2d.Utils;
using UnityEngine.Events;
using Platformer2d.Engine.Game.UI;

namespace Platformer2d.Engine.Game
{
    internal sealed class DamageableUnit : IDamageableUnit,IHealUnit
    {
        private int _healthUnit;
        private int _maxHealthUnit;
        private bool _isAlive;
        private bool _isInvicibility;
        private Animator _unitAnimator;
        private Rigidbody2D _unitRigidbody;
        private float _invicibilityTime;
        private float _timeSinceHit;
        private UIGameModel _uiGameModel;

        public UnityAction OnDeath;
        public UnityAction OnHit;
        public UnityAction OnHeal;

        public int MaxHealth
        {
            get { return _maxHealthUnit; }
            set { _maxHealthUnit = value; }
        }

        public int Health
        {
            get { return _healthUnit; }
            set
            {
                _healthUnit = value;

                if (_healthUnit <= 0)
                {
                    IsAlive = false;
                }
            }
        }

        public bool IsAlive
        {
            get { return _isAlive; }
            set
            {
                _isAlive = value;
                _unitAnimator.SetBool(GameConstantsForAnimation.IsAlive,value);

                if (value == false)
                {
                    OnDeath?.Invoke();
                }
            }
        }

        public bool LockVelocity
        {
            get { return _unitAnimator.GetBool(GameConstantsForAnimation.LockVelocity); }
            set { _unitAnimator.SetBool(GameConstantsForAnimation.LockVelocity, value); }
        }

        public DamageableUnit(int healthUnit, int maxHealthUnit,float invicibilityTime, Animator unitAnimator,Rigidbody2D unitRigidbody, UIGameModel uiGameModel)
        {
            _healthUnit = healthUnit;
            _maxHealthUnit = maxHealthUnit;
            _unitAnimator = unitAnimator;
            _invicibilityTime = invicibilityTime;
            _isAlive = true;
            _unitRigidbody = unitRigidbody;
            _uiGameModel = uiGameModel;
        }

        public bool Hit(int damage,Vector2 knockback)
        {
            if (damage > Health)
            {
                damage = Health;
            }

            if (IsAlive && !_isInvicibility)
            {
                _isInvicibility = true;
                Health -= damage;
                _unitRigidbody.velocity = new Vector2(knockback.x, _unitRigidbody.velocity.y + knockback.y);
                _unitAnimator.SetTrigger(GameConstantsForAnimation.HitTrigger);
                LockVelocity = true;
                _uiGameModel.OnTakeDamageUnit?.Invoke(_unitRigidbody.transform.position, damage);
                OnHit?.Invoke();
                return true;
            }
            return false;
        }

        public void HitTimer()
        {
            if (_isInvicibility)
            {
                if (_timeSinceHit > _invicibilityTime)
                {
                    _isInvicibility = false;
                    _timeSinceHit = 0;
                }

                _timeSinceHit += Time.deltaTime;
            }
        }

        public bool Heal(int healthRestore)
        {
            if(IsAlive && Health<MaxHealth)
            {
                int maxHeal = Mathf.Max(MaxHealth - Health, 0);
                int actualHeal = Mathf.Min(maxHeal, healthRestore);
                Health += actualHeal;
                _uiGameModel.OnHealedUnit?.Invoke(_unitRigidbody.transform.position, actualHeal);
                OnHeal?.Invoke();
                return true;
            }
            return false;
        }
    }
}
