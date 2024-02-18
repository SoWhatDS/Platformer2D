using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    [CreateAssetMenu(fileName = nameof(LaserBeamerModel),menuName = "Settings/ " + nameof(LaserBeamerModel))]
    public sealed class LaserBeamerModel : ScriptableObject
    {
        [field: SerializeField] public int TakeDamage { get; private set; }
        [field: SerializeField] public Vector2 KnockBack { get; private set; }
    }
}
