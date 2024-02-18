using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Game
{
    [CreateAssetMenu(fileName = nameof(PlayerManagerModel), menuName = "Settings/ " + nameof(PlayerManagerModel))]
    public class PlayerManagerModel : ScriptableObject
    {
        public Action<bool> OnGameOver;
        public Action<bool> OnLevelComplete;
    }
}
