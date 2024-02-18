using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    [CreateAssetMenu(fileName = nameof(CoinModel),menuName = "Settings/ " + nameof(CoinModel))]
    public sealed class CoinModel : ScriptableObject
    {
        [field: SerializeField] public Vector3 SpeedRotation { get; private set; }
    }
}
