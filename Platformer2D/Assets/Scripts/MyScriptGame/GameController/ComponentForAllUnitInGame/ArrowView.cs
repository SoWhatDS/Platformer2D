using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Game.Player
{
    [RequireComponent(typeof(Rigidbody2D),typeof(Collider2D))]
    internal sealed class ArrowView : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody2D Rigidbody;
        [field: SerializeField] public Collider2D Collider;

        private int _attackDamage;
        private Vector2 _knockback;
        private bool _gotHit = false;
        private bool _isSpawning = false;

        private float _timer;
        private float _countDown = 5f;

        public bool GotHit { get { return _gotHit; }
                             set { _gotHit = value;}}

        public bool IsSpawning { get { return _isSpawning; }
                                 set { _isSpawning = value; }}

        public void BowAttack(Vector2 moveSpeed)
        {
            Rigidbody.velocity = new Vector2(moveSpeed.x * transform.localScale.x, moveSpeed.y);
        }

        public void SpawnArrowTimer()
        {
            _timer += Time.deltaTime;

            if (_timer >= _countDown)
            {
                _isSpawning = false;
                _timer = 0f; 
            }
            else
            {
                _isSpawning = true;
            }
        }

        public void Init(int attackDamage, Vector2 knockBack)
        {
            _attackDamage = attackDamage;
            _knockback = knockBack;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IDamageableUnit damageableUnit = collision.GetComponent<IDamageableUnit>();

            if (damageableUnit != null)
            {
                Vector2 deliveredKnockBack = transform.localScale.x > 0 ? _knockback : new Vector2(_knockback.x * -1, _knockback.y);
                _gotHit = damageableUnit.Hit(_attackDamage, deliveredKnockBack);
            }
        }
    }
}
