using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    [CreateAssetMenu(fileName = nameof(PushButtonDownModel),menuName = "Settings/ " + nameof(PushButtonDownModel))]
    public class PushButtonDownModel : ScriptableObject
    {
        [field: SerializeField] public int TakeDamage { get; private set; }
        [field: SerializeField] public Vector2 KnockBack { get; private set; }
        [field: SerializeField] public Vector3 SpeedDown { get; private set; }
    }
}
