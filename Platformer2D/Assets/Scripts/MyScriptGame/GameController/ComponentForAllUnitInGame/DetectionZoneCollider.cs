using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Platformer2d.Engine.Game
{
    [RequireComponent(typeof(Collider2D))]
    internal sealed class DetectionZoneCollider : MonoBehaviour
    {
        [field: SerializeField] public Collider2D _detectedZoneCollider;

        private bool _isColliderCollission = false;
        public UnityAction<bool> OnCollisionDetected;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _isColliderCollission = true;
            OnCollisionDetected?.Invoke(_isColliderCollission);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {            
            _isColliderCollission = false;
            OnCollisionDetected?.Invoke(_isColliderCollission);
        }


    }
}
