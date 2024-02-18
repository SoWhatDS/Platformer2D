using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    internal sealed class WrapsView : MonoBehaviour
    {
        [field: SerializeField] public List<LaserBeamerView> LaserBeamerList;
        [field: SerializeField] public List<PushButtonDownView> PushButtonsDownList;
    }
}
