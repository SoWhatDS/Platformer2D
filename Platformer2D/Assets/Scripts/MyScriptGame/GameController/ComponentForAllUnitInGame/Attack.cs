using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2d.Engine.Game.Player;
using UnityEngine.Events;

namespace Platformer2d.Engine.Game
{
    internal sealed class Attack : MonoBehaviour
    {
        private int _attackDamage;
        private Vector2 _knockback;

        public void Init(int attackDamage,Vector2 knockBack)
        {
            _attackDamage = attackDamage;
            _knockback = knockBack;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IDamageableUnit damageableUnit = collision.GetComponent<IDamageableUnit>();

            if (damageableUnit != null)
            {
                Vector2 deliveredKnockBack = transform.parent.localScale.x > 0 ? _knockback : new Vector2(_knockback.x * -1, _knockback.y);
                damageableUnit.Hit(_attackDamage,deliveredKnockBack);
            }
        }
    }
}
