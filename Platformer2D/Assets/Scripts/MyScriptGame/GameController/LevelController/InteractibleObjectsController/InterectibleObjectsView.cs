using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    internal sealed class InterectibleObjectsView : MonoBehaviour
    {
        [field: SerializeField] public PlatformsView Platforms;
        [field: SerializeField] public UIHealthPickUpView UIHealthPickUp;
        [field: SerializeField] public WrapsView Wraps;
        [field: SerializeField] public CoinsView CoinsOnMap;
    }
}
