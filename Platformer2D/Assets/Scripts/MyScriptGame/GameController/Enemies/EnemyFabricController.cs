using System.Collections;
using System.Collections.Generic;
using Platformer2d.Engine.Game.UI;
using UnityEngine;

namespace Platformer2d.Engine.Game.Enemy
{
    internal sealed class EnemyFabricController : BaseController
    {
        private KnightEnemyFabric _knightEnemyFabric;
        private FlyingEyeEnemyFabric _flyingEyeEnemyFabric;
        private List<Transform> _startPointsForKnight;
        private List<Transform> _startPointsForFlyingEye;


        public EnemyFabricController(FlyingEyeEnemyFabric flyingEyeEnemyFabric,KnightEnemyFabric knightEnemyFabric,
            List<Transform> startRespawnPointsForKnight,List<Transform> startRespawnPointsForFlyingEye)
        {
            _startPointsForFlyingEye = startRespawnPointsForFlyingEye;
            _startPointsForKnight = startRespawnPointsForKnight;
            _knightEnemyFabric = knightEnemyFabric;
            _flyingEyeEnemyFabric = flyingEyeEnemyFabric;
            CreateAllEnemiesInLevel();
        }

        private void CreateAllEnemiesInLevel()
        {
            CreateAllFlyingEyeInMap();
            CreateAllKnightsInMap();
        }

        private void CreateAllKnightsInMap()
        {
            for (int i = 0; i < _startPointsForKnight.Count; i++)
            {
                AddControllers(_knightEnemyFabric.CreateEnemy(_startPointsForKnight[i]));
            }
        }

        private void CreateAllFlyingEyeInMap()
        {
            for (int i = 0; i < _startPointsForFlyingEye.Count; i++)
            {
                AddControllers(_flyingEyeEnemyFabric.CreateEnemy(_startPointsForFlyingEye[i]));
            }
        }
    }
}
