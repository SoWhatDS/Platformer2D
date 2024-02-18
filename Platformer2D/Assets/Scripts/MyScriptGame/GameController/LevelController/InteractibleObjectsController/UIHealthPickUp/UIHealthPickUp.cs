using System.Collections;
using System.Collections.Generic;
using Platformer2d.Engine.Game;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    [RequireComponent(typeof(Collider2D))]
    internal sealed class UIHealthPickUp : MonoBehaviour
    {
        private int _healthRestore;
        private bool _isDestroy;

        public bool IsDestroyedGameObject
        {
            get { return _isDestroy; }
        }

        public void Init(int healthRestore)
        {
            _healthRestore = healthRestore;
            _isDestroy = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<IDamageableUnit>(out IDamageableUnit damageableUnit))
            {
                if (damageableUnit is IHealUnit healUnit)
                {
                    bool wasHealed = healUnit.Heal(_healthRestore);

                    if (wasHealed)
                    {
                        _isDestroy = true;
                        Destroy(gameObject);
                    }                 
                }
            }
        }

        public void RotationPickUp(Vector3 spinRotationSpeed)
        {
            transform.eulerAngles += spinRotationSpeed * Time.deltaTime;
        }
    }
}
