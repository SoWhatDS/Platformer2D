using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Level.InterectableObjects
{
    [CreateAssetMenu(fileName = nameof(InterectibleObjectsModel),menuName = "Settings/ " + nameof(InterectibleObjectsModel))]
    public class InterectibleObjectsModel : ScriptableObject
    {
        [field: SerializeField] public UIHealthPickUpModel UIHealthPickUpModel;
        [field: SerializeField] public WrapsModel WrapsModel;
        [field: SerializeField] public CoinModel CoinModel;
    }
}
