using System.Collections;
using System.Collections.Generic;
using Platformer2d.Engine.Game;
using UnityEngine;

namespace Platformer2d.Engine.LevelSelect
{
    [CreateAssetMenu(fileName = nameof(Map),menuName = "LevelSelect/ " + nameof(Map))]
    public class Map : ScriptableObject
    {
        [field: SerializeField] public int mapIndex { get; private set; }
        [field: SerializeField] public string mapName { get; private set; }
        [field: SerializeField] public string mapDescription { get; private set; }
        [field: SerializeField] public Sprite mapImage { get; private set; }
        [field: SerializeField] public GameObject loadLevel { get; private set; }

    }
}
