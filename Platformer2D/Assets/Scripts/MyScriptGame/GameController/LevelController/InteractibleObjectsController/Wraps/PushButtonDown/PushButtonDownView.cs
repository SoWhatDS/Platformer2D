using System.Collections;
using System.Collections.Generic;
using Platformer2d.Engine.Game;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    [RequireComponent(typeof(Collider2D))]
    internal sealed class PushButtonDownView : MonoBehaviour
    {
        [field: SerializeField] public ArrowDownView ArrowDownView { get; private set; }
        [field: SerializeField] public bool IsButtonDown { get; private set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IDamageableUnit damageableUnit))
            {
                IsButtonDown = true;
                ArrowDownView.gameObject.SetActive(true);
            }
        }
    }
}
