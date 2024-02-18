using System.Collections;
using System.Collections.Generic;
using Platformer2d.Engine.Game;
using Platformer2d.Engine.Game.Enemy;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    [RequireComponent(typeof(SliderJoint2D),typeof(Collider2D))]
    internal sealed class HorizontalViewPlatform : MonoBehaviour,IMovementPlatform
    {
        [SerializeField] private SliderJoint2D _sliderJoint;
        [SerializeField] private DetectionZoneCollider _detectedCollider;

        private enum MovementDirection { Right, Left };
        private MovementDirection _movementDirection;

        private MovementDirection MoveDirection
        {
            get { return _movementDirection; }
            set
            {
                if (_movementDirection != value)
                {
                    gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                    if (value == MovementDirection.Right)
                    {
                        _sliderJoint.angle = 180;
                    }
                    else if (value == MovementDirection.Left)
                    {
                        _sliderJoint.angle = 0;
                    }
                }
                _movementDirection = value;
            }
        }

        private void FlipDirection(bool hasCollission)
        {
            if (hasCollission)
            {
                if (MoveDirection == MovementDirection.Right)
                {
                    MoveDirection = MovementDirection.Left;
                }
                else if (MoveDirection == MovementDirection.Left)
                {
                    MoveDirection = MovementDirection.Right;
                }
                else
                {
                    Debug.Log("Current walkable direction is not set to legal values of right or left");
                }
            }
        }

        public void SubscribeToFlipDirection()
        {
            _detectedCollider.OnCollisionDetected += FlipDirection;
        }

        public void UnSubscribeToFlipDirection()
        {
            _detectedCollider.OnCollisionDetected -= FlipDirection;
        }
    }
}
