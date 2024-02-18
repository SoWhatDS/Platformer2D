using System.Collections;
using System.Collections.Generic;
using Platformer2d.Engine.Game;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    [RequireComponent(typeof(Collider2D))]
    internal sealed class DeathZoneView : MonoBehaviour
    {
        private int _immortalDamage = 100;
        private Vector2 _deathKnockback = new Vector2();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<IDamageableUnit>(out IDamageableUnit damageableUnit))
            {
                damageableUnit.Hit(_immortalDamage, _deathKnockback);
            }
        }
    }
}
