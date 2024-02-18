using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    [CreateAssetMenu(fileName = nameof(WrapsModel), menuName = "Settings/ " + nameof(WrapsModel))]
    public sealed class WrapsModel : ScriptableObject
    {
        [field: SerializeField] public LaserBeamerModel LaserBeamerModel { get; private set; }
        [field: SerializeField] public PushButtonDownModel PushButtonDownModel { get; private set; }
    }
}
