using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Game.Player
{
    internal class PlayerMovement : IMoveRigidbodyPlayer
    {
        private readonly Rigidbody2D _playerRigidbody;
        private bool _isFacingRight = true;

        public bool IsFacingRight
        {
            get
            {
                return _isFacingRight;
            }
            set
            {
                if (_isFacingRight != value)
                {
                   _playerRigidbody.transform.localScale *= new Vector2(-1, 1);
                }
                _isFacingRight = value;
            }
        }

        public PlayerMovement(Rigidbody2D playerRigidbody)
        {
            _playerRigidbody = playerRigidbody;
        }

        public void RigidbodyMove(Vector2 moveInput, float currentMoveSpeed)
        {
            _playerRigidbody.velocity = new Vector2(moveInput.x * currentMoveSpeed, _playerRigidbody.velocity.y);

            SetFacingDirection(moveInput);
        }

        private void SetFacingDirection(Vector2 moveInput)
        {
            if (moveInput.x > 0 && !IsFacingRight)
            {
                IsFacingRight = true;
            }
            else if (moveInput.x < 0 && IsFacingRight)
            {
                IsFacingRight = false;
            }
        }

        public void RigidbodyJump(float jumpImpulse)
        {
            _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x,jumpImpulse);
        }

    }
}

