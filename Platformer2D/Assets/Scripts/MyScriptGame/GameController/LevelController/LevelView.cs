using System.Collections;
using System.Collections.Generic;
using Platformer2d.Engine.BackGround;
using Platformer2d.Engine.Game;
using Platformer2d.Engine.Game.UI;
using Platformer2d.Engine.Level.InterectableObjects;
using UnityEngine;

namespace Platformer2d.Engine.Level
{
    internal sealed class LevelView : MonoBehaviour
    {
        [field: SerializeField] public BackGroundView BackGroundView;
        [field: SerializeField] public UIGameView UIGameView;
        [field: SerializeField] public InterectibleObjectsView InterectibleObjectsView;
        [field: SerializeField] public List<Transform> RespawnPointsForKnight;
        [field: SerializeField] public List<Transform> RespwanPointForFlyingEye;
        [field: SerializeField] public Transform StartRespwanPlayerPoint;
        [field: SerializeField] public DetectionZoneCollider EndLevelPoint;


    }
}
