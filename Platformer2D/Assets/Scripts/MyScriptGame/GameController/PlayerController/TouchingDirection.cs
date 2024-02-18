using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2d.Utils;

namespace Platformer2d.Engine.Game
{
    internal sealed class TouchingDirection
    {
        //isGrounded
        private Animator _animator;
        private Collider2D _touchingCollider;
        private ContactFilter2D _castFilter;
        private RaycastHit2D[] _groundHits = new RaycastHit2D[5];
        private float _groundDistance = 0.05f;

        //isOnWall
        private Vector2 _wallCheckDirection;
        private RaycastHit2D[] _wallHits = new RaycastHit2D[5];
        private float _wallDistance = 0.2f;

        //isOnCeiling
        private RaycastHit2D[] _ceilingHits = new RaycastHit2D[5];
        private float _ceilingDistance = 0.05f;

        private bool _isGrounded;
        private bool _isOnWall;
        private bool _isOnCeiling;

        public bool IsGrounded
        {
            get
            {
                return _isGrounded;
            }
            set
            {
                _isGrounded = value;
                _animator.SetBool(GameConstantsForAnimation.IsGrounded, value);
            }
        }

        public bool IsOnWall
        {
            get
            {
                return _isOnWall;
            }
            set
            {
                _isOnWall = value;
                _animator.SetBool(GameConstantsForAnimation.IsOnWall,value);
            }
        }

        public bool IsOnCeiling
        {
            get
            {
                return _isOnCeiling;
            }
            set
            {
                _isOnCeiling = value;
                _animator.SetBool(GameConstantsForAnimation.IsOnCeiling,value);
            }
        }

        public TouchingDirection(Collider2D touchingCollider,Animator animator,ContactFilter2D contactFilter)
        {
            _touchingCollider = touchingCollider;
            _animator = animator;
            _castFilter = contactFilter;
        }

        public void CheckTouching()
        {
            IsGrounded = _touchingCollider.Cast(Vector2.down, _castFilter, _groundHits, _groundDistance) > 0;

            _wallCheckDirection = _touchingCollider.gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;
            IsOnWall = _touchingCollider.Cast(_wallCheckDirection,_castFilter,_wallHits,_wallDistance) > 0;
            IsOnCeiling = _touchingCollider.Cast(Vector2.up, _castFilter, _ceilingHits, _ceilingDistance) > 0;
        }

    }
}
