using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2d.Utils;

namespace Platformer2d.Engine.Game.Enemy
{
    internal sealed class FlyingEyeView : MonoBehaviour,IDamageableUnit
    {
        [field: SerializeField] public Rigidbody2D Rigidbody;
        [field: SerializeField] public Collider2D Collider;
        [field: SerializeField] public Attack BiteAttack;
        [field: SerializeField] public Animator Animator;
        [field: SerializeField] public DetectionZoneCollider DetectionZoneTarget;
        [field: SerializeField] public Collider2D DeathCollider;
        [field: SerializeField] public AudioSource AudioSource;
        [field: SerializeField] public List<Transform> WayPoints;

        private IDamageableUnit _damageableUnit;
        private bool _hasTarget;

        public bool HasTarget
        {
            get { return _hasTarget; }
            set
            {
                _hasTarget = value;
                Animator.SetBool(GameConstantsForAnimation.HasTarget,value);
            }
        }

        public bool CanMove
        {
            get { return Animator.GetBool(GameConstantsForAnimation.CanMove); }
        }

        public void Init(IDamageableUnit damageableUnit)
        {
            _damageableUnit = damageableUnit;
        }

        public bool Hit(int damage, Vector2 knockback)
        {
           return _damageableUnit.Hit(damage,knockback);
        }

        public void HitTimer()
        {
            _damageableUnit.HitTimer(); 
        }
    }
}
