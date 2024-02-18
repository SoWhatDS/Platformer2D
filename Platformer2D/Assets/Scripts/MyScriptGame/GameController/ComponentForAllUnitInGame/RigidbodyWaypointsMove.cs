using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Game.Enemy
{
    internal sealed class RigidbodyWaypointsMove 
    {
        private Rigidbody2D _rigidbodyUnit;
        private List<Transform> _waypoints;
        private FlyingEyeView _flyingEyeView;

        private int _currentWaypoint = 0;
        private Transform _nextWaypoint;
        private float _minDistanceToSwitchWaypoint = 0.1f;

        public RigidbodyWaypointsMove(FlyingEyeView flyingEyeView,List<Transform> waypoints)
        {
            _flyingEyeView = flyingEyeView;
            _rigidbodyUnit = _flyingEyeView.Rigidbody;
            _waypoints = waypoints;
            _nextWaypoint = _waypoints[_currentWaypoint];
        }

        public void RigidbodyMoveOnWaypoints(float moveSpeed)
        {
            Vector2 directionToWaypoint = (_nextWaypoint.transform.position - _flyingEyeView.transform.position).normalized;
            float distanceToWaypoint = Vector2.Distance(_nextWaypoint.position,_flyingEyeView.transform.position);
            _rigidbodyUnit.velocity = directionToWaypoint * moveSpeed;

            FlipDirection();

            if (distanceToWaypoint <= _minDistanceToSwitchWaypoint)
            {
                _currentWaypoint++;

                if (_currentWaypoint >= _waypoints.Count)
                {
                    _currentWaypoint = 0;
                }

                _nextWaypoint = _waypoints[_currentWaypoint];
            }
        }

        private void FlipDirection()
        {
            Vector3 localscale = _flyingEyeView.transform.localScale;

            if (_flyingEyeView.transform.localScale.x < 0)
            {
                if (_rigidbodyUnit.velocity.x > 0)
                {
                    _flyingEyeView.transform.localScale = new Vector3(-1 * localscale.x, localscale.y, localscale.z);
                }
            }
            else
            {
                if (_rigidbodyUnit.velocity.x < 0)
                {
                    _flyingEyeView.transform.localScale = new Vector3(-1 * localscale.x, localscale.y, localscale.z);
                }
            }
        }
    }
}
