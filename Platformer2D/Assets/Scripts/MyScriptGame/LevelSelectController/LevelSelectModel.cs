using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.LevelSelect
{
    [CreateAssetMenu(fileName = nameof(LevelSelectModel),menuName = "Settings/ " + nameof(LevelSelectModel))]
    internal sealed class LevelSelectModel : ScriptableObject
    {
        [field: SerializeField] public Map[] Maps;

        public Action<int> OnChangeableMapIndex;

    }
}
