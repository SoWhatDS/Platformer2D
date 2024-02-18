using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d.Engine.Game
{
    internal sealed class PlayerManagerView : MonoBehaviour
    {
        [field: SerializeField] public GameOverView GameOverView;
        [field: SerializeField] public EndLevelView EndLevelView;
    }
}
