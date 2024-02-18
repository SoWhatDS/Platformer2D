using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    [CreateAssetMenu(fileName = nameof(UIHealthPickUpModel), menuName = "Settings/ " + nameof(UIHealthPickUpModel))]
    public class UIHealthPickUpModel : ScriptableObject
    {
        [field: SerializeField] public Vector3 RotationSpeed { get; private set; }
        [field: SerializeField] public int HealthRestore { get; private set; }
    }
}
