using System.Collections;
using System.Collections.Generic;
using Platformer2d.Engine.Game;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    [RequireComponent(typeof(SliderJoint2D), typeof(Collider2D))]
    internal sealed class VerticalPlatformView : MonoBehaviour, IMovementPlatform
    {
        [SerializeField] private SliderJoint2D _sliderJoint;
        [SerializeField] private DetectionZoneCollider _detectedCollider;

        public enum MovementDirection { Up, Down };
        private MovementDirection _movementDirection;

        private MovementDirection MoveDirection
        {
            get { return _movementDirection; }
            set
            {
                if (_movementDirection != value)
                {
                    if (value == MovementDirection.Up)
                    {
                        _sliderJoint.angle = 90;
                    }
                    else if (value == MovementDirection.Down)
                    {
                        _sliderJoint.angle = -90;
                    }
                }

                _movementDirection = value;
            }
        }

        private void FlipDirection(bool hasCollission)
        {
            if (hasCollission)
            {
                if (MoveDirection == MovementDirection.Up)
                {
                    MoveDirection = MovementDirection.Down;
                }
                else if (MoveDirection == MovementDirection.Down)
                {
                    MoveDirection = MovementDirection.Up;
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
