using System.Collections;
using System.Collections.Generic;
using Platformer2d.Engine.Game;
using Platformer2d.Engine.Game.Player;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    [RequireComponent(typeof(Collider2D))]
    internal sealed class CoinView : MonoBehaviour
    {
        private bool _isDestroy;

        public bool IsDestroyedGameObject
        {
            get { return _isDestroy; }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<ITakeCoins>(out ITakeCoins takeCoin))
            { 
                takeCoin.TakeCoin();
                _isDestroy = true;
                Destroy(gameObject);
            }
        }

        public void RotationCoin(Vector3 spinRotationSpeed)
        {
            transform.eulerAngles += spinRotationSpeed * Time.deltaTime;
        }
    }
}
