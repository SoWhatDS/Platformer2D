using System.Collections;
using System.Collections.Generic;
using Platformer2d.Engine.Game;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    [RequireComponent(typeof(Collider2D))]
    internal sealed class ArrowDownView : MonoBehaviour
    {
        private int _takeDamage;
        private Vector2 _knockBack;
        private Vector3 _speedDown;

        public void Init(int takeDamage,Vector2 knockBack,Vector2 speedDown)
        {
            _takeDamage = takeDamage;
            _knockBack = knockBack;
            _speedDown = speedDown;
            gameObject.SetActive(false);
        }

        public void MoveDown()
        {
            transform.position -= _speedDown;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IDamageableUnit damageableUnit))
            {
                damageableUnit.Hit(_takeDamage, _knockBack);
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
