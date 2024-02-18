using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2d.Utils;
using Platformer2d.Engine.Game.UI;

namespace Platformer2d.Engine.Game.Enemy
{
    internal sealed class EnemyView : MonoBehaviour,IDamageableUnit
    {
        [field: SerializeField] public Rigidbody2D Rigidbody;
        [field: SerializeField] public Collider2D Collider;
        [field: SerializeField] public Animator Animator;
        [field: SerializeField] public Vector2 WalkDirectionVector;
        [field: SerializeField] public ContactFilter2D ContactFilter;
        [field: SerializeField] public Attack AttackCollider;
        [field: SerializeField] public DetectionZoneCollider ClifDetectionZone;
        [field: SerializeField] public DetectionZoneCollider DetectionZoneTarget;
        [field: SerializeField] public AudioSource AudioSource;

        public enum WalkableDirection { Right,Left};
        private WalkableDirection _walkDirection;
        private bool _hasTarget;
        private bool _hasClifDetectionZone;
        private IDamageableUnit _damageableUnit;
        private int _attackDamage;
        private UIGameModel _uiGameModel;

        public bool HasTarget
        {
            get { return _hasTarget; }
            set
            {
                _hasTarget = value;
                Animator.SetBool(GameConstantsForAnimation.HasTarget, value);
            }
        }

        public bool HasClifDetectionZone
        {
            get { return _hasClifDetectionZone; }
            set { _hasClifDetectionZone = value; }
        }

        public bool CanMove
        {
            get { return Animator.GetBool(GameConstantsForAnimation.CanMove); }
        }

        public WalkableDirection WalkDirection
        {
            get { return _walkDirection; }
            set
            {
                if (_walkDirection != value)
                {
                    gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                    if (value == WalkableDirection.Right)
                    {
                        WalkDirectionVector = Vector2.right;
                    }
                    else if (value == WalkableDirection.Left)
                    {
                        WalkDirectionVector = Vector2.left;
                    }
                }
                _walkDirection = value;
            }
        }

        public void Init(IDamageableUnit damageableUnit,UIGameModel uiGameModel)
        {
            _damageableUnit = damageableUnit;
            _uiGameModel = uiGameModel;
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
