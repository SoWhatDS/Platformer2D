using System.Collections;
using System.Collections.Generic;
using Platformer2d.Engine.Game;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    [RequireComponent(typeof(Collider2D))]
    internal sealed class LaserBeamerView : MonoBehaviour
    {
        private int _takeDamage;
        private Vector2 _knockBack;

        public void Init(int takeDamage,Vector2 knockBack)
        {
            _takeDamage = takeDamage;
            _knockBack = knockBack;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<IDamageableUnit>(out IDamageableUnit damageableUnit))
            {
                damageableUnit.Hit(_takeDamage,_knockBack);
            }
        }

    }
}
