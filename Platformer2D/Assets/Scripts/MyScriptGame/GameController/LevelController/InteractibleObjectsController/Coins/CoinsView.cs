using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    internal sealed class CoinsView : MonoBehaviour
    {
        [field: SerializeField] public List<CoinView> CoinsListOnMap;
    }
}
